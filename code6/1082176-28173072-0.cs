    class Program
    {
        static void Main(string[] args)
        {
            object sync = new object;
            int j=0;
            Parallel.For(0, 10000000, i =>
                {
                    lock(sync)
                    {
                      j++;
                    }
                });
            Console.WriteLine(j);
            Console.ReadKey();
        }
    } 
