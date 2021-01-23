    public void Activate()
    {
        //Task.Factory.StartNew(() =>
        //BAD IDEA, IT WOULD RUN ON UI THREAD IF CALLED FROM UI!
        //UNLESS EXPLICITLY REQUESTED TaskScheduler.Default
    
        Task.Run(
        {
            //NOW IT REALLY executes on thread pool ALWAYS.
            return GetSomething(); // returns a Task.
        }) // returns a Task<Task>.
        .Unwrap() // "unwraps" the outer task, returning a proxy
                  // for the inner one returned by GetSomething().
        .ContinueWith(task =>
        {
            // executes in UI thread.
            Prop = task.Result;
        }, TaskScheduler.FromCurrentSynchronizationContext()/* THIS IS DEFAULT*/);
    }
