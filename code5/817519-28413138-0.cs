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
            DateTime start = DateTime.Now;
            Console.WriteLine("async: Starting");
            Task wait = Task.Delay(5000);
            Console.WriteLine("async: Running for {0} seconds", DateTime.Now.Subtract(start).TotalSeconds);
            await wait;
            Console.WriteLine("async: Running for {0} seconds", DateTime.Now.Subtract(start).TotalSeconds);
            Console.WriteLine("async: Done");
        }
        static void syncCode()
        {
            DateTime start = DateTime.Now;
            Console.WriteLine("sync: Starting");
            Thread.Sleep(5000);
            Console.WriteLine("sync: Running for {0} seconds", DateTime.Now.Subtract(start).TotalSeconds);
            Console.WriteLine("sync: Done");
        }
    }
