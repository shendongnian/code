    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Linq;
        using System.Reactive.Linq;
        using System.Threading;
        using System.Threading.Tasks;
        using System.Threading.Tasks.Schedulers;
    
        internal class Program
        {
            #region Constants
    
            private const int ChunkSize = 50;
    
            #endregion
    
            #region Methods
    
            private static void Main(string[] args)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                var workStealingTaskScheduler = new WorkStealingTaskScheduler(Environment.ProcessorCount - 1);
                var bag = new ConcurrentBag<Task>();
                IEnumerable<string> bigList = Enumerable.Range(0, 10000).Select(s => s.ToString());
                bigList.ToObservable().Buffer(ChunkSize).Subscribe(
                    chunk => bag.Add(
                        Task.Factory.StartNew(
                            () =>
                            {
                                foreach (string s in chunk)
                                {
                                    Console.WriteLine(s);
                                }
                                Console.WriteLine(String.Empty.PadRight(80, '-'));
                            },
                            cancellationToken,
                            TaskCreationOptions.None,
                            workStealingTaskScheduler)));
                Task.WaitAll(bag.ToArray());
            }
    
            #endregion
        }
    }
