    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        internal class Program
        {
            // worker
            private static void DoWork(CancellationToken token)
            {
                for (int i = 0; i < 1000; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(100); // do the work item
                }
                token.ThrowIfCancellationRequested();
            }
    
            // test
            private static void Main()
            {
                var userCt = new CancellationTokenSource();
                var combinedCt = CancellationTokenSource.CreateLinkedTokenSource(
                    userCt.Token);
                combinedCt.CancelAfter(3000); // cancel in 3 seconds
    
                Console.CancelKeyPress += (s, e) =>
                {
                    e.Cancel = true;
                    userCt.Cancel();
                };
    
                var task = Task.Run(
                    () => DoWork(combinedCt.Token), 
                    combinedCt.Token);
                try
                {
                    task.Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    if (task.IsCanceled)
                    {
                        if (userCt.Token.IsCancellationRequested)
                            Console.WriteLine("Cancelled by user");
                        else if (combinedCt.Token.IsCancellationRequested)
                            Console.WriteLine("Cancelled by time-out");
                        else 
                            Console.WriteLine("Cancelled by neither user not time-out");
                    }
                }
            }
        }
    }
