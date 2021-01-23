    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21628490
    {
        // Test
        class Program
        {
            static async Task DoWorkAsync()
            {
                using (var scheduler = new SerialTaskScheduler())
                {
                    var tasks = Enumerable.Range(1, 10).Select(i =>
                        scheduler.Run(() =>
                        {
                            var sleep = 1000 / i;
                            Thread.Sleep(sleep);
                            Console.WriteLine("Task #" + i + ", sleep: " + sleep);
                        }, CancellationToken.None));
    
                    await Task.WhenAll(tasks);
                }
            }
    
            static void Main(string[] args)
            {
                DoWorkAsync().Wait();
                Console.ReadLine();
            }
        }
    
        // SerialTaskScheduler
        public sealed class SerialTaskScheduler : TaskScheduler, IDisposable
        {
            Task _schedulerTask;
            BlockingCollection<Task> _tasks;
            Thread _schedulerThread;
    
            public SerialTaskScheduler()
            {
                _tasks = new BlockingCollection<Task>();
    
                _schedulerTask = Task.Run(() =>
                {
                    _schedulerThread = Thread.CurrentThread;
    
                    foreach (var task in _tasks.GetConsumingEnumerable())
                        TryExecuteTask(task);
                });
            }
    
            protected override void QueueTask(Task task)
            {
                _tasks.Add(task);
            }
    
            protected override IEnumerable<Task> GetScheduledTasks()
            {
                return _tasks.ToArray();
            }
    
            protected override bool TryExecuteTaskInline(
                Task task, bool taskWasPreviouslyQueued)
            {
                return _schedulerThread == Thread.CurrentThread &&
                    TryExecuteTask(task);
            }
    
            public override int MaximumConcurrencyLevel
            {
                get { return 1; }
            }
    
            public void Dispose()
            {
                if (_schedulerTask != null)
                {
                    _tasks.CompleteAdding();
                    _schedulerTask.Wait();
                    _tasks.Dispose();
                    _tasks = null;
                    _schedulerTask = null;
                }
            }
    
            public Task Run(Action action, CancellationToken token)
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this);
            }
    
            public Task Run(Func<Task> action, CancellationToken token)
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this).Unwrap();
            }
    
            public Task<T> Run<T>(Func<Task<T>> action, CancellationToken token)
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, this).Unwrap();
            }
        }
    }
