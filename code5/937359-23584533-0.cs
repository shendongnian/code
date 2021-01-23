        internal class Program
        {
            private static void Main(string[] args)
            {
                // setup the factory
                LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler(9);
                TaskFactory f = new TaskFactory(lcts);
                // create my shared task queue
                ConcurrentDictionary<string, Task> waiting = new ConcurrentDictionary<string, Task>();
                ConcurrentBag<Task> finished = new ConcurrentBag<Task>();
                // some numbers....
                List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
                foreach (int n in nums)
                {
                    int i = n; // if you don't do this, n is 0 when it writes to the Debug console....
                    Task t = f.StartNew(() =>
                    {
                        Debug.WriteLine(i);
                        // some more numbers....
                        List<int> other = new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
                        foreach (int nm in other)
                        {
                            int j = i;
                            int w = nm;
                            Task tk = f.StartNew(() =>
                            {
                                Debug.WriteLine(j + "," + w);
                                Thread.Sleep(1000);
                            });
                            waiting.TryAdd(j + "," + w, tk);
                        }
                        Thread.Sleep(500);
                    });
                    waiting.TryAdd(i.ToString(), t);
                }
                // loop until no further tasks are waiting.
                while (waiting.Count > 0)
                {
                    // run the tasks...
                    Task.WaitAll(waiting.Values.ToArray());
                    // remove the finised tasks from the waiting list.
                    foreach (KeyValuePair<string, Task> pair in waiting)
                    {
                        if (pair.Value.IsCompleted)
                        {
                            finished.Add(pair.Value);
                            Task o;
                            waiting.TryRemove(pair.Key, out o);
                        }
                    }
                    Thread.Sleep(100);
                }
            }
        }
        /// <summary>
        /// Provides a task scheduler that ensures a maximum concurrency level while
        /// running on top of the ThreadPool.
        /// </summary>
        public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
        {
            /// <summary>Whether the current thread is processing work items.</summary>
            [ThreadStatic]
            private static bool _currentThreadIsProcessingItems;
            /// <summary>The list of tasks to be executed.</summary>
            private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)
            /// <summary>The maximum concurrency level allowed by this scheduler.</summary>
            private readonly int _maxDegreeOfParallelism;
            /// <summary>Whether the scheduler is currently processing work items.</summary>
            private int _delegatesQueuedOrRunning = 0; // protected by lock(_tasks)
            /// <summary>
            /// Initializes an instance of the LimitedConcurrencyLevelTaskScheduler class with the
            /// specified degree of parallelism.
            /// </summary>
            /// <param name="maxDegreeOfParallelism">The maximum degree of parallelism provided by this scheduler.</param>
            public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
            {
                if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
                _maxDegreeOfParallelism = maxDegreeOfParallelism;
            }
            /// <summary>Queues a task to the scheduler.</summary>
            /// <param name="task">The task to be queued.</param>
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
            /// <summary>
            /// Informs the ThreadPool that there's work to be executed for this scheduler.
            /// </summary>
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
            /// <summary>Attempts to execute the specified task on the current thread.</summary>
            /// <param name="task">The task to be executed.</param>
            /// <param name="taskWasPreviouslyQueued"></param>
            /// <returns>Whether the task could be executed on the current thread.</returns>
            protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
            {
                // If this thread isn't already processing a task, we don't support inlining
                if (!_currentThreadIsProcessingItems) return false;
                // If the task was previously queued, remove it from the queue
                if (taskWasPreviouslyQueued) TryDequeue(task);
                // Try to run the task.
                return base.TryExecuteTask(task);
            }
            /// <summary>Attempts to remove a previously scheduled task from the scheduler.</summary>
            /// <param name="task">The task to be removed.</param>
            /// <returns>Whether the task could be found and removed.</returns>
            protected sealed override bool TryDequeue(Task task)
            {
                lock (_tasks) return _tasks.Remove(task);
            }
            /// <summary>Gets the maximum concurrency level supported by this scheduler.</summary>
            public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }
            /// <summary>Gets an enumerable of the tasks currently scheduled on this scheduler.</summary>
            /// <returns>An enumerable of the tasks currently scheduled.</returns>
            protected sealed override IEnumerable<Task> GetScheduledTasks()
            {
                bool lockTaken = false;
                try
                {
                    Monitor.TryEnter(_tasks, ref lockTaken);
                    if (lockTaken) return _tasks.ToArray();
                    else throw new NotSupportedException();
                }
                finally
                {
                    if (lockTaken) Monitor.Exit(_tasks);
                }
            }
        }
