    class Program
    {
        double[] a = new double[] { 1, 3, 4, 8, 21, 38 };
        double[] b = new double[] { 1, 7, 19, 3, 2, 24 };
        double[] result;
        public double[] CheckSorting()
        {
            for(int i = 1; i < a.Length; i++)
            {
                if (a[i] < a[i - 1])
                    result = b;
                else
                    result = a;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Program checkSorting = new Program();
            checkSorting.CheckSorting();
            Console.ReadLine();
        }
    }
