        static Matrix m;
        static void SetDataSet()
        {
            double[] y11 = new double[7] { 24, 13.3, 12.2, 14, 22.2, 16.1, 27.9 };
            double[] y12 = new double[7] { 3.5, 3.5, 4, 4, 3.6, 4.3, 5.2 };
            double[] y21 = new double[7] { 7.4, 13.2, 8.5, 10.1, 9.3, 8.5, 4.3 };
            double[] y22 = new double[7] { 3.5, 3, 3, 3, 2, 2.5, 1.5 };
            double[] y31 = new double[5] { 16.4, 24, 53, 32.7, 42.8 };
            double[] y32 = new double[5] { 3.2, 2.5, 1.5, 2.6, 2 };
            double[] y41 = new double[2] { 25.1, 5.9 };
            double[] y42 = new double[2] { 2.7, 2.3 };
            m.Add(y11, 0, 0);
            m.Add(y12, 0, 1);
            m.Add(y21, 1, 0);
            m.Add(y22, 1, 1);
            m.Add(y31, 2, 0);
            m.Add(y32, 2, 1);
            m.Add(y41, 3, 0);
            m.Add(y42, 3, 1);
        }
        static void Main(string[] args)
        {
            m = new Matrix(4,2);
            SetDataSet();
            m.Print();
            Console.ReadLine();
        }
    }
