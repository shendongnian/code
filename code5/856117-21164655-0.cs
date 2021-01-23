        static void Main(string[] args)
        {
            int[] Array = new int[] { 10, 233, 34 };
            int _MaxVal = CalculateMax(Array);
            Console.WriteLine(_MaxVal);
            Console.ReadKey();
        }
        private static int CalculateMax(int[] Array)
        {
            int max = 0;
            for (int i = 0; i < Array.Length; i++)
                if (Array[i] > max)
                    max = Array[i];
            return max;
        }
