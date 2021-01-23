    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        class Program
        {
            // the method to monitor and timeout
            int Method()
            {
                Thread.Sleep(1000 * 60 * 3); // sleep for 3 mins
                return 42;
            }
    
            async Task<int> MethodAsync(int timeout)
            {
                // start the Method task
                var task1 = Task.Run(() => Method());
    
                // start the timeout task
                var task2 = Task.Delay(timeout);
    
                // either task1 or task2
                var task = await Task.WhenAny(task1, task2);
                if (task == task1)
                    return task1.Result;
    
                throw new TaskCanceledException();
            }
    
            // The entry of the console app
            static void Main(string[] args)
            {
                try
                {
                    // timeout in 2 mins
                    int result = new Program().MethodAsync(1000 * 60 * 2).Result;
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine("Hit enter to exit.");
                Console.ReadLine();
            }
        }
    }
