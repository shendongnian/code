    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            void run()
            {
                CancellationTokenSource cancellation = new CancellationTokenSource(
                  TimeSpan.FromSeconds(8));
                Console.WriteLine("Starting action loop.");
                RepeatActionEvery(() => Console.WriteLine("Action"), 
                  TimeSpan.FromSeconds(1), cancellation.Token).Wait();
                Console.WriteLine("Finished action loop.");
            }
            public static async Task RepeatActionEvery(Action action, 
              TimeSpan interval, CancellationToken cancellationToken)
            {
                while (true)
                {
                    action();
                    Task task = Task.Delay(interval, cancellationToken);
                    try
                    {
                        await task;
                    }
                    catch (TaskCanceledException)
                    {
                        return;
                    }
                }
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
