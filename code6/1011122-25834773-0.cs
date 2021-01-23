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
    
                        var task1 = CreateFirstTask(cancellationTokenSource);
                        var task2 = CreateSecondTask(cancellationTokenSource);
                        var task3 = CreateThirdTask(cancellationTokenSource);
    
                        task1.Start();
                        await task1;
                        task2.Start();
                        await task2;
                        task3.Start();
                        await task3;
                        Console.WriteLine("Done");
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
    
                public Task CreateFirstTask(CancellationTokenSource cancelSource)
                {
                    return new Task(
                        () =>
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
    
                public Task CreateSecondTask(CancellationTokenSource cancelSource)
                {
                    return new Task(
                        () =>
                        {
                            Console.WriteLine("Second Task is Running");
                        },
                        cancelSource.Token);
                }
    
                public Task CreateThirdTask(CancellationTokenSource cancelSource)
                {
                    return new Task(
                        () =>
                        {
                            Console.WriteLine("Third Task is Running");
                        },
                        cancelSource.Token);
                }
            }
        }
    }
