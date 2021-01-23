    var sameStackFrame = true
    try
    {
        //TODO: also use TaskScheduler.Default rather than TaskScheduler.Current 
        Task newTask = _lastScheduledTask.ContinueWith(completedTask => 
        {
            if (sameStackFrame) // avoid potential recursion
               return completedTask.ContinueWith(_ => SafeWrapCallback(action));
            else 
            {
               SafeWrapCallback(action);
               return completedTask;
            }
        }, TaskContinuationOptions.ExecuteSynchronously).Unwrap();
    
        _lastScheduledTask = newTask;    
    }
    finally
    {
        sameStackFrame = false;
    }
