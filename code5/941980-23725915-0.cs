    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            Console.WriteLine("Press any key to call method or press Esc to cancel");
    
            do
            {
                Method();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    
        static Task delayTask = null;
        static CancellationTokenSource cancellationTokenSource = null;
    
        static void Method()
        {
            Console.WriteLine("Method called");
    
            if (delayTask != null)
            {
                cancellationTokenSource.Cancel();
            }
    
            cancellationTokenSource = new CancellationTokenSource();
            delayTask = Task.Delay(5000, cancellationTokenSource.Token);
            delayTask.ContinueWith((t) => {
                Console.WriteLine("Task running...");
            }, TaskContinuationOptions.NotOnCanceled);
        }
    }
