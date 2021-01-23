    try
    {
    System.Console.WriteLine("Starting fizzLoop.");
                var fizzTask = Task.Factory.StartNew(new Action(fizzLoop));
    
                System.Console.WriteLine("Starting buzzLoop.");
                var buzzTask = Task.Factory.StartNew(new Action(buzzLoop));
    
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
