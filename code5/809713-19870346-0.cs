    try
    {
        await Task.Run(async () =>
                            {
                                await Task.Delay(5000);
                                throw new Exception("Test1");
                            });
    }
    catch (AggregateException ae)
    {
        foreach (var ex in ae.Flatten().InnerExceptions)
        {
                    
        }
    }
