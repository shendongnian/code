        static void Main(string[] args)
        {
            for (int i = 0; i < 1000000; i++)
            {
                int i1 = i;
                Task.Run(() => Console.WriteLine(i1));
            }
            Console.ReadKey();
        }
