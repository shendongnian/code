    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static DateTime start;
            static CancellationTokenSource tokenSource;
            static void Main(string[] args)
            {
                start = DateTime.Now;
                Console.WriteLine(start);
    
                
                TaskDelayTest();
    
                TaskCancel();
    
                Console.ReadKey();
            }
    
            public static async void TaskCancel()
            {
                await Task.Delay(3000);
    
                tokenSource?.Cancel();
    
                DateTime end = DateTime.Now;
                Console.WriteLine(end);
                Console.WriteLine((end - start).TotalMilliseconds);
            }
    
            public static async void TaskDelayTest()
            {
                tokenSource = new CancellationTokenSource();
    
                try
                {
                    await Task.Delay(2000, tokenSource.Token);
                    DateTime end = DateTime.Now;
                    Console.WriteLine(end);
                    Console.WriteLine((end - start).TotalMilliseconds);
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    tokenSource.Dispose();
                    tokenSource = null;
                }
            }
        }
    }
