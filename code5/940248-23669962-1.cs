    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        public static class TaskExt
        {
            public static Task<TResult> TaskWithCancellation<TResult>(
                this TaskCompletionSource<TResult> @this,
                CancellationToken token)
            {
                var registration = token.Register(() => @this.TrySetCanceled());
                return @this.Task.ContinueWith(
                    task => { registration.Dispose(); return task.Result; },
                    token, 
                    TaskContinuationOptions.LazyCancellation | 
                        TaskContinuationOptions.ExecuteSynchronously, 
                    TaskScheduler.Default);
            }
        }
    
        class Program
        {
            static async Task TestAsync(Task task, CancellationToken token)
            {
                try
                {
                    await task;
                }
                catch (OperationCanceledException ex)
                {
                    if (token != ex.CancellationToken)
                        throw;
                    Console.WriteLine("Cancelled with the correct token");
                }
            }
    
            static void Main(string[] args)
            {
                var cts = new CancellationTokenSource(1000);
                var tcs = new TaskCompletionSource<object>();
    
                var taskWithCancellation = tcs.TaskWithCancellation(cts.Token);
                try
                {
                    TestAsync(taskWithCancellation, cts.Token).Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                Console.ReadLine();
            }
        }
    }
