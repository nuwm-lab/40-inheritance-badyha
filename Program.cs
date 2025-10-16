using System;

namespace LabWork
{
    // Даний проект є шаблоном для виконання лабораторних робіт
    // з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
    // Необхідно змінювати і дописувати код лише в цьому проекті
    // Відео-інструкції щодо роботи з github можна переглянути 
    // за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 
    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрація роботи класів Vector4 та Matrix4x4
            var vec = new Vector4();
            vec.SetElements(new double[] { 1.5, -2.0, 3.25, 0.75 });
            Console.WriteLine("Vector (size 4):");
            vec.Print();
            Console.WriteLine($"Max element in vector: {vec.MaxElement():F2}\n");

            var mat = new Matrix4x4();
            // Заповнимо матрицю прикладними значеннями
            mat.SetElements(new double[] {
                1, 2, 3, 4,
                -1.5, 0, 7, 2.25,
                3.14, -9, 8, 0,
                0.5, 0.5, 0.5, 0.5
            });
            Console.WriteLine("Matrix (4x4):");
            mat.Print();
            Console.WriteLine($"Max element in matrix: {mat.MaxElement():F2}");
        }
    }

    // Одновимірний вектор розмірності 4
    class Vector4
    {
        protected double[] elements = new double[4];

        // Задати елементи вектора (масив повинен мати довжину 4)
        public void SetElements(double[] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length != 4) throw new ArgumentException("Vector must have exactly 4 elements.");
            for (int i = 0; i < 4; i++) elements[i] = values[i];
        }

        // Вивести вектор на екран
        public virtual void Print()
        {
            Console.WriteLine("[ " + string.Join(", ", elements) + " ]");
        }

        // Знайти максимальний елемент вектора
        public virtual double MaxElement()
        {
            double max = elements[0];
            for (int i = 1; i < elements.Length; i++)
                if (elements[i] > max) max = elements[i];
            return max;
        }
    }

    // Матриця 4x4 як похідний клас від Vector4
    class Matrix4x4 : Vector4
    {
        // Ми зберігатимемо матрицю в одному масиві довжини 16 (рядково)
        private double[] data = new double[16];

        // Задати елементи матриці з масиву довжини 16
        public new void SetElements(double[] values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length != 16) throw new ArgumentException("Matrix must have exactly 16 elements (4x4).");
            for (int i = 0; i < 16; i++) data[i] = values[i];
        }

        // Перевизначене виведення матриці
        public override void Print()
        {
            for (int r = 0; r < 4; r++)
            {
                Console.Write("[ ");
                for (int c = 0; c < 4; c++)
                {
                    Console.Write(data[r * 4 + c]);
                    if (c < 3) Console.Write(", ");
                }
                Console.WriteLine(" ]");
            }
        }

        // Знайти максимальний елемент матриці
        public override double MaxElement()
        {
            double max = data[0];
            for (int i = 1; i < data.Length; i++)
                if (data[i] > max) max = data[i];
            return max;
        }
    }
}
