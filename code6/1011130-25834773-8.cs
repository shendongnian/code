    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
    
        class Program
        {
            static void Main(string[] args)
            {
                new MyClass().RunAsyncMethods();
                Console.ReadLine();
    
            }
    
            public class MyClass
            {
                public async void RunAsyncMethods()
                {
                    try
                    {
                        var cancellationTokenSource = new CancellationTokenSource();
    
                        var task1 = RunFirstTaskAsync(cancellationTokenSource);
                        var task2 = RunSecondTaskAsync(cancellationTokenSource);
    
                        await Task.WhenAll(task1, task2);
                        await RunThirdTaskAsync(cancellationTokenSource);
                        Console.WriteLine("Done");
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
    
                public Task RunFirstTaskAsync(CancellationTokenSource cancelSource)
                {
                    return Task.Run(() =>
                    {
                        try
                        {
                            Console.WriteLine("First Task is Running");
                            throw new Exception("Error happened in first task");
                        }
                        catch (Exception exception)
                        {
                            cancelSource.Cancel();
    
                            throw;
                        }
                    },
                        cancelSource.Token);
                }
    
                public Task RunSecondTaskAsync(CancellationTokenSource cancelSource)
                {
                    return Task.Run(
                        () =>
                        {
                            Console.WriteLine("Second Task is Running");
                        },
                        cancelSource.Token);
                }
    
                public Task RunThirdTaskAsync(CancellationTokenSource cancelSource)
                {
                    return Task.Run(
                        () =>
                        {
                            Console.WriteLine("Third Task is Running");
                        },
                        cancelSource.Token);
                }
            }
        }
    }
