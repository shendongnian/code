        static void Main(string[] args)
        {
            RunTasksWithDelays();
        }
        static void RunTasksWithDelays()
        {
            var s = Stopwatch.StartNew();
            var tasks = Enumerable.Range(0, 50).Select(i => LongRunningTask()).ToArray();
            // Don't need explicit wait, .Result does it effectively.
            Console.WriteLine(tasks.SelectMany(t => t.Result).Distinct().Count());
            Console.WriteLine(s.Elapsed);
            Console.WriteLine(Environment.ProcessorCount);
        }
        static async Task<List<int>> LongRunningTask()
        {
            await Task.Yield(); // Force task to complete asyncronously.
            var threadList = new List<int> {Thread.CurrentThread.ManagedThreadId};
            var count = 200000000;
            while (count-- > 0) ;
            threadList.Add(Thread.CurrentThread.ManagedThreadId);
            return threadList;
        }
