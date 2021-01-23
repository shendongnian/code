    class Program
    {
        const int SIZE = 3000;
        static double[,] data = new double[SIZE,SIZE];
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "/for")
            {
                Benchmark(ForLoop);
            }
            else
            {
                Benchmark(LinqLoop);
            }
        }
        static void ForLoop()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    if (double.IsNaN(data[i, j]) || double.IsInfinity(data[i, j])) Console.WriteLine("FOUND!");
                }
            }
        }
        static void LinqLoop()
        {
            if (!data.Cast<double>().Any(d => double.IsNaN(d) || double.IsInfinity(d))) Console.WriteLine("FOUND!");
        }
        static void Benchmark(Action a)
        {
            Stopwatch watch = Stopwatch.StartNew();
            a();
            TimeSpan span = watch.Elapsed;
            Console.WriteLine("Milliseconds: " + span.TotalMilliseconds + " ms");
            Console.ReadKey();
        }
    }
