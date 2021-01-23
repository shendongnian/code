     static void Main(string[] args)
        {
            int[] one= { 1, 3, 4, 6, 7 };
            int[] second = { 1, 2, 4, 5 };
            foreach (int r in one.Intersect(second))
                Console.WriteLine(r);
            Console.ReadLine();
        }
