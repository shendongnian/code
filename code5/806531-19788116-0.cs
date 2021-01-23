    class Program
    {
        private static readonly Random Random = new Random();
        private static readonly ConcurrentExclusiveSchedulerPair TaskSchedulerPair = new ConcurrentExclusiveSchedulerPair();
        static void Main()
        {
            DoSomething(false);
            DoSomething(false);
            DoSomething(true);
            DoSomething(false);
            DoSomething(false);
            Console.Read();
        }
        private static void DoSomething(bool singleThread)
        {
            var scheduler = singleThread ? TaskSchedulerPair.ExclusiveScheduler : TaskSchedulerPair.ConcurrentScheduler;
            Task.Factory.StartNew(() =>
            {
                if (singleThread)
                    Console.WriteLine("Starting exclusive task.");
                DoSomething();
            }, new CancellationToken(), TaskCreationOptions.LongRunning, scheduler)
                .ContinueWith(_ =>
                {
                    if (singleThread)
                        Console.WriteLine("Finished exclusive task.");
                });
        }
        private static void DoSomething()
        {
            Console.WriteLine("Starting task on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(Random.Next(1000, 5000));
            Console.WriteLine("Finished task on thread {0}.", Thread.CurrentThread.ManagedThreadId);
        }
    }
