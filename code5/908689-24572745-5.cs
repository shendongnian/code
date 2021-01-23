        public class Program
        {
            public delegate void ThisDoesSomething();
    
            // Perform a very simple operation to see the overhead of
            // different async calls types.
            public static void Main(string[] args)
            {
                const int repetitions = 25;
                const int calls = 1000;
                var results = new List<Tuple<string, double>>();
    
                Console.WriteLine(
                    "{0} parallel calls, {1} repetitions for better statistics\n", 
                    calls, 
                    repetitions);
    
                // Threads
                Console.Write("Running Threads");
                results.Add(new Tuple<string, double>("Threads", RunOnThreads(repetitions, calls)));
                Console.WriteLine();
    
                // BeginInvoke
                Console.Write("Running BeginInvoke");
                results.Add(new Tuple<string, double>("BeginInvoke", RunOnBeginInvoke(repetitions, calls)));
                Console.WriteLine();
    
                // Tasks
                Console.Write("Running Tasks");
                results.Add(new Tuple<string, double>("Tasks", RunOnTasks(repetitions, calls)));
                Console.WriteLine();
    
                // Thread Pool
                Console.Write("Running Thread pool");
                results.Add(new Tuple<string, double>("ThreadPool", RunOnThreadPool(repetitions, calls)));
                Console.WriteLine();
                Console.WriteLine();
    
                // Show results
                results = results.OrderBy(rs => rs.Item2).ToList();
                foreach (var result in results)
                {
                    Console.WriteLine(
                        "{0}: Done in {1}ms avg", 
                        result.Item1,
                        (result.Item2 / repetitions).ToString("0.00"));
                }
                
                Console.WriteLine("Press a key to exit");
                Console.ReadKey();
            }
    
            /// <summary>
            /// The do stuff.
            /// </summary>
            public static void DoStuff()
            {
                Console.Write("*");
            }
    
            public static double RunOnThreads(int repetitions, int calls)
            {
                var totalMs = 0.0;
                for (var j = 0; j < repetitions; j++)
                {
                    Console.Write(".");
                    var toProcess = calls;
                    var stopwatch = new Stopwatch();
                    var resetEvent = new ManualResetEvent(false);
                    var threadList = new List<Thread>();
                    for (var i = 0; i < calls; i++)
                    {
                        threadList.Add(new Thread(() =>
                        {
                            // Do something
                            DoStuff();
    
                            // Safely decrement the counter
                            if (Interlocked.Decrement(ref toProcess) == 0)
                            {
                                resetEvent.Set();
                            }
                        }));
                    }
    
                    stopwatch.Start();
                    foreach (var thread in threadList)
                    {
                        thread.Start();
                    }
    
                    resetEvent.WaitOne();
                    stopwatch.Stop();
                    totalMs += stopwatch.ElapsedMilliseconds;
                }
    
                return totalMs;
            }
    
            public static double RunOnThreadPool(int repetitions, int calls)
            {
                var totalMs = 0.0;
                for (var j = 0; j < repetitions; j++)
                {
                    Console.Write(".");
                    var toProcess = calls;
                    var resetEvent = new ManualResetEvent(false);
                    var stopwatch = new Stopwatch();
                    var list = new List<int>();
                    for (var i = 0; i < calls; i++)
                    {
                        list.Add(i);
                    }
    
                    stopwatch.Start();
                    for (var i = 0; i < calls; i++)
                    {
                        ThreadPool.QueueUserWorkItem(
                            x =>
                            {
                                // Do something
                                DoStuff();
    
                                // Safely decrement the counter
                                if (Interlocked.Decrement(ref toProcess) == 0)
                                {
                                    resetEvent.Set();
                                }
                            },
                            list[i]);
                    }
    
                    resetEvent.WaitOne();
                    stopwatch.Stop();
                    totalMs += stopwatch.ElapsedMilliseconds;
                }
    
                return totalMs;
            }
    
            public static double RunOnBeginInvoke(int repetitions, int calls)
            {
                var totalMs = 0.0;
                for (var j = 0; j < repetitions; j++)
                {
                    Console.Write(".");
                    var beginInvokeStopwatch = new Stopwatch();
                    var delegateList = new List<ThisDoesSomething>();
                    var resultsList = new List<IAsyncResult>();
                    for (var i = 0; i < calls; i++)
                    {
                        delegateList.Add(DoStuff);
                    }
    
                    beginInvokeStopwatch.Start();
                    foreach (var delegateToCall in delegateList)
                    {
                        resultsList.Add(delegateToCall.BeginInvoke(null, null));
                    }
    
                    // We lose a bit of accuracy, but if the loop is big enough,
                    // it should not really matter
                    while (resultsList.Any(rs => !rs.IsCompleted))
                    {
                        Thread.Sleep(10);
                    }
    
                    beginInvokeStopwatch.Stop();
                    totalMs += beginInvokeStopwatch.ElapsedMilliseconds;
                }
    
                return totalMs;
            }
    
            public static double RunOnTasks(int repetitions, int calls)
            {
                var totalMs = 0.0;
                for (var j = 0; j < repetitions; j++)
                {
                    Console.Write(".");
                    var resultsList = new List<Task>();
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (var i = 0; i < calls; i++)
                    {
                        resultsList.Add(Task.Factory.StartNew(DoStuff));
                    }
    
                    // We lose a bit of accuracy, but if the loop is big enough,
                    // it should not really matter
                    while (resultsList.Any(task => !task.IsCompleted))
                    {
                        Thread.Sleep(10);
                    }
    
                    stopwatch.Stop();
                    totalMs += stopwatch.ElapsedMilliseconds;
                }
    
                return totalMs;
            }
        }
