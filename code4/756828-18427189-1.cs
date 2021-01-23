    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                // wait for 5 seconds or user hit Enter key cancel the task
                Thread.Sleep(5000);
                DoStuff();
            });
            Console.WriteLine("Here's the main thread.");
            Console.Read();
        }
        private static void DoStuff()
        {
            Console.WriteLine("Task done!");
        }
    }
