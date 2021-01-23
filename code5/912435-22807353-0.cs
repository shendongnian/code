    static class Program
    {
        private static readonly Random Rnd = new Random((int)DateTime.UtcNow.Ticks);
        static void Main(string[] args)
        {            
            var stopwatch = new Stopwatch();
            
            stopwatch.Start();
            bool isFound;
            while (true)
            {
                isFound = Find();
                if (isFound || stopwatch.Elapsed.TotalSeconds >= 10)
                    break;
            }
            Console.WriteLine("Is found: {0}, Spent time: {1} sec(s)", isFound, stopwatch.Elapsed.TotalSeconds);
            Console.ReadLine();
        }
        private static bool Find()
        {
            return Rnd.Next(1000) >= 999;
        }
    }
