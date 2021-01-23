    public static Task TimeoutAfter(this Task task, int millisecondsTimeout)
    {
        // Short-circuit #1: infinite timeout or task already completed
        if (task.IsCompleted || (millisecondsTimeout == Timeout.Infinite))
        {
            // Either the task has already completed or timeout will never occur.
            // No proxy necessary.
            return task;
        }
    
        // tcs.Task will be returned as a proxy to the caller
        TaskCompletionSource<VoidTypeStruct> tcs = 
            new TaskCompletionSource<VoidTypeStruct>();
    
        // Short-circuit #2: zero timeout
        if (millisecondsTimeout == 0)
        {
            // We've already timed out.
            tcs.SetException(new TimeoutException());
            return tcs.Task;
        }
    
        // Set up a timer to complete after the specified timeout period
        Timer timer = new Timer(state => 
        {
            // Recover your state information
            var myTcs = (TaskCompletionSource<VoidTypeStruct>)state;
    
            // Fault our proxy with a TimeoutException
            myTcs.TrySetException(new TimeoutException()); 
        }, tcs, millisecondsTimeout, Timeout.Infinite);
    
        // Wire up the logic for what happens when source task completes
        task.ContinueWith((antecedent, state) =>
        {
            // Recover our state data
            var tuple = 
                (Tuple<Timer, TaskCompletionSource<VoidTypeStruct>>)state;
    
            // Cancel the Timer
            tuple.Item1.Dispose();
    
            // Marshal results to proxy
            MarshalTaskResults(antecedent, tuple.Item2);
        }, 
        Tuple.Create(timer, tcs),
        CancellationToken.None,
        TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
    
        return tcs.Task;
    }
