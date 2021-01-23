    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            // async/await version
            static async Task<int> Test1Async(Task<int> task)
            {
                return await task;
            }
    
            // TPL version
            static Task<int> Test2Async(Task<int> task)
            {
                return task.ContinueWith(
                    t => t.Result,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
            }
    
            static void Tester(string name, Func<Task<int>, Task<int>> func)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                for (int i = 0; i < 10000000; i++)
                {
                    func(Task.FromResult(0)).Wait();
                }
                sw.Stop();
                Console.WriteLine("{0}: {1}ms", name, sw.ElapsedMilliseconds);
            }
    
            static void Main(string[] args)
            {
                Tester("Test1Async", Test1Async);
                Tester("Test2Async", Test2Async);
            }
        }
    }
