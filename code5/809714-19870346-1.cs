    Task.Run(async () =>
    {
        await Task.Delay(5000);
        throw new Exception("Test1");
    }).ContinueWith(task =>
                        {
                            foreach (var ex in task.Exception.Flatten().InnerExceptions)
                            {
                                        
                            }
                        }, TaskContinuationOptions.OnlyOnFaulted);
