    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplications
    {
        class Program
        {
            static void Main(string[] args)
            {
                ThreadPool.SetMinThreads(100, 100);
    
                Console.WriteLine("start, " + new { System.Environment.CurrentManagedThreadId });
    
                var tcs = new TaskCompletionSource<bool>();
    
                // test ContinueWith-style continuations (TaskContinuationOptions.ExecuteSynchronously)
                ContinueWith(1, tcs.Task);
                ContinueWith(2, tcs.Task);
                ContinueWith(3, tcs.Task);
    
                // test await-style continuations
                ContinueAsync(4, tcs.Task);
                ContinueAsync(5, tcs.Task);
                ContinueAsync(6, tcs.Task);
    
                Task.Run(() =>
                {
                    Console.WriteLine("before SetResult, " + new { System.Environment.CurrentManagedThreadId });
                    tcs.TrySetResult(true);
                    Thread.Sleep(10000);
                });
                Console.ReadLine();
            }
    
            // log
            static void Continuation(int id)
            {
                Console.WriteLine(new { continuation = id, System.Environment.CurrentManagedThreadId });
                Thread.Sleep(1000);
            }
    
            // await-style continuation
            static async Task ContinueAsync(int id, Task task)
            {
                await task.ConfigureAwait(false);
                Continuation(id);
            }
    
            // ContinueWith-style continuation
            static Task ContinueWith(int id, Task task)
            {
                return task.ContinueWith(
                    t => Continuation(id),
                    CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
            }
        }
    }
