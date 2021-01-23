    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    
    namespace Console_21690385
    {
        class Program
        {
            const int MAX_REQS = 100;
    
            // test using GetStringAsync
            static async Task Test1()
            {
                var httpClient = new HttpClient();
    
                var tasks = Enumerable.Range(1, MAX_REQS).Select((i) =>
                    httpClient.GetStringAsync("http://www.bing.com/search?q=item1=" + i));
    
                Console.WriteLine("Threads before completion: " + Process.GetCurrentProcess().Threads.Count);
    
                await Task.WhenAll(tasks);
    
                Console.WriteLine("Threads after completion: " + Process.GetCurrentProcess().Threads.Count);
            }
    
            // test using request.GetResponse
            static async Task Test2()
            {
                int maxThreads, maxPorts;
                ThreadPool.GetMaxThreads(out maxThreads, out maxPorts);
                var scheduler = new LimitedConcurrencyLevelTaskScheduler(maxPorts);
    
                var tasks = Enumerable.Range(1, MAX_REQS).Select((i) =>
                    Task.Factory.StartNew(() =>
                    {
                        var request = WebRequest.Create("http://www.bing.com/search?q=item1=" + i);
                        using (var response = request.GetResponse())
                        using (var stream = response.GetResponseStream())
                        using (var reader = new System.IO.StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }, CancellationToken.None, TaskCreationOptions.PreferFairness, scheduler));
    
                Console.WriteLine("Threads before completion: " + Process.GetCurrentProcess().Threads.Count);
    
                await Task.WhenAll(tasks);
    
                Console.WriteLine("Threads after completion: " + Process.GetCurrentProcess().Threads.Count);
            }
    
            // run either of the tests
            static void RunTest(Func<Task> runTest)
            {
                Console.WriteLine("Threads at start: " + Process.GetCurrentProcess().Threads.Count);
    
                var stopWatch = new Stopwatch();
                stopWatch.Start();
    
                var testTask = runTest();
    
                while (!testTask.IsCompleted)
                {
                    Console.WriteLine("Currently threads: " + Process.GetCurrentProcess().Threads.Count);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Threads at end: " + Process.GetCurrentProcess().Threads.Count + ", time: " + stopWatch.Elapsed);
    
                testTask.Wait();
            }
    
            static void Main(string[] args)
            {
                ThreadPool.SetMaxThreads(MAX_REQS*2, MAX_REQS*2);
                ThreadPool.SetMinThreads(MAX_REQS, MAX_REQS);
    
                Console.WriteLine("Testing using async httpClient.GetStringAsync");
                RunTest(Test1);
                Console.ReadLine();
    
                Console.WriteLine("Testing using sync WebRequest.Create");
                RunTest(Test2);
                Console.ReadLine();
            }
    
            // Provides a task scheduler that ensures a maximum concurrency level while  
            // running on top of the thread pool.
            // http://msdn.microsoft.com/en-us/library/ee789351(v=vs.110).aspx
    
            public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
            {
                // Indicates whether the current thread is processing work items.
                [ThreadStatic]
                private static bool _currentThreadIsProcessingItems;
    
                // The list of tasks to be executed  
                private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks) 
    
                // The maximum concurrency level allowed by this scheduler.  
                private readonly int _maxDegreeOfParallelism;
    
                // Indicates whether the scheduler is currently processing work items.  
                private int _delegatesQueuedOrRunning = 0;
    
                // Creates a new instance with the specified degree of parallelism.  
                public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
                {
                    if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
                    _maxDegreeOfParallelism = maxDegreeOfParallelism;
                }
    
                // Queues a task to the scheduler.  
                protected sealed override void QueueTask(Task task)
                {
                    // Add the task to the list of tasks to be processed.  If there aren't enough  
                    // delegates currently queued or running to process tasks, schedule another.  
                    lock (_tasks)
                    {
                        _tasks.AddLast(task);
                        if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                        {
                            ++_delegatesQueuedOrRunning;
                            NotifyThreadPoolOfPendingWork();
                        }
                    }
                }
    
                // Inform the ThreadPool that there's work to be executed for this scheduler.  
                private void NotifyThreadPoolOfPendingWork()
                {
                    ThreadPool.UnsafeQueueUserWorkItem(_ =>
                    {
                        // Note that the current thread is now processing work items. 
                        // This is necessary to enable inlining of tasks into this thread.
                        _currentThreadIsProcessingItems = true;
                        try
                        {
                            // Process all available items in the queue. 
                            while (true)
                            {
                                Task item;
                                lock (_tasks)
                                {
                                    // When there are no more items to be processed, 
                                    // note that we're done processing, and get out. 
                                    if (_tasks.Count == 0)
                                    {
                                        --_delegatesQueuedOrRunning;
                                        break;
                                    }
    
                                    // Get the next item from the queue
                                    item = _tasks.First.Value;
                                    _tasks.RemoveFirst();
                                }
    
                                // Execute the task we pulled out of the queue 
                                base.TryExecuteTask(item);
                            }
                        }
                        // We're done processing items on the current thread 
                        finally { _currentThreadIsProcessingItems = false; }
                    }, null);
                }
    
                // Attempts to execute the specified task on the current thread.  
                protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
                {
                    // If this thread isn't already processing a task, we don't support inlining 
                    if (!_currentThreadIsProcessingItems) return false;
    
                    // If the task was previously queued, remove it from the queue 
                    if (taskWasPreviouslyQueued)
                        // Try to run the task.  
                        if (TryDequeue(task))
                            return base.TryExecuteTask(task);
                        else
                            return false;
                    else
                        return base.TryExecuteTask(task);
                }
    
                // Attempt to remove a previously scheduled task from the scheduler.  
                protected sealed override bool TryDequeue(Task task)
                {
                    lock (_tasks) return _tasks.Remove(task);
                }
    
                // Gets the maximum concurrency level supported by this scheduler.  
                public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }
    
                // Gets an enumerable of the tasks currently scheduled on this scheduler.  
                protected sealed override IEnumerable<Task> GetScheduledTasks()
                {
                    bool lockTaken = false;
                    try
                    {
                        Monitor.TryEnter(_tasks, ref lockTaken);
                        if (lockTaken) return _tasks;
                        else throw new NotSupportedException();
                    }
                    finally
                    {
                        if (lockTaken) Monitor.Exit(_tasks);
                    }
                }
            }
        }
    }
