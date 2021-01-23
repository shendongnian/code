    task1 = Task.Run(() => Log(arg1, arg2, arg3));
    
    try
    {
        task1.Wait();
    }
    catch (AggregateException ae)
    {
        // Assume we know what's going on with this particular exception. 
        // Rethrow anything else. AggregateException.Handle provides 
        
        foreach (var e in ae.InnerExceptions)
        {
            if (e is MyCustomException)
            {
                Console.WriteLine(e.Message);
            }
            else
            {
                throw;
            }
        }
    
    }
