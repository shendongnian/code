    Task task = Task.Factory.StartNew(() => 
    { 
        throw new UnauthorizedAccessException(); 
    }); 
    try
    {
        task.Wait();
    }
    catch (AggregateException ex)
    {
        ex.Handle(x =>
        {
            if (x is UnauthorizedAccessException)
            {
                // Handle this exception...
                return true;
            }
            // Other exceptions will not be handled here.
            return false;
        });
    }
