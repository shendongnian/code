    var prevCtx = SynchronizationContext.Current; 
    try 
    {
        SynchronizationContext.SetSynchronizationContext(new ThreadPoolSynchronizationContext()); 
        
        // async operations.
    } 
    finally 
    {  
        SynchronizationContext.SetSynchronizationContext(prevCtx); 
    } 
