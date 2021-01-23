    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Starting..");
            sw.Start();
            Console.ReadLine();
            sw.Stop();
            Console.WriteLine("Elapsed time {0}:{1}:{2}:{3}", sw.Elapsed.Hours.ToString("00"), sw.Elapsed.Minutes.ToString("00"), sw.Elapsed.Seconds.ToString("00"), sw.Elapsed.Milliseconds);
        }
    }
