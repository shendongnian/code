    try
    {
        t.Wait();
    }
    catch (AggregateException ae)
    {
        // Assume we know what's going on with this particular exception. 
        // Rethrow anything else. AggregateException.Handle provides 
        // another way to express this. See later example. 
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
