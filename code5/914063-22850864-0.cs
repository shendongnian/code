    CancellationTokenSource mainCancellationTokenSource = new CancellationTokenSource();
    
                    Task task1 = new Task(() =>
                    {
                        try
                        {
                            throw new Exception("Exception message");
                        }
                        catch (Exception ex)
                        {
                            mainCancellationTokenSource.Cancel();
                        }
                       
                    }, mainCancellationTokenSource.Token);
    
                    Task task2 = new Task(() =>
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                        Console.WriteLine("Task is running");
    
                    }, mainCancellationTokenSource.Token);
    
                    task1.Start();
                    task2.Start();
    
                    Task.WaitAll(new[] { task1, task2}, 
                                 6000, // 6 seconds
                                 mainCancellationTokenSource.Token
                                );
                }
                catch (Exception ex)
                {   
                    // If any exception thrown on any of the tasks, break out immediately instead of wait all the way to 60 seconds.
                }
