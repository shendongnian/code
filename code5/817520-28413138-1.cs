    class Program
    {
        static void Main(string[] args)
        {
            Task wait = asyncTask();
            syncCode();
            wait.Wait();
            Console.ReadLine();
        }
        static async Task asyncTask()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("async: Starting");
            Task wait = Task.Delay(5000);
            Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            await wait;
            Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("async: Done");
        }
        static void syncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("sync: Starting");
            Thread.Sleep(5000);
            Console.WriteLine("sync: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("sync: Done");
        }
    }
