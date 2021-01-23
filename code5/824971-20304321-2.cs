    public void Activate()
    {
        Task.Factory.StartNew(() =>
        {
            //executes in thread pool.
            return GetSomething(); // returns a Task.
        }) // returns a Task<Task>.
        .Unwrap() // "unwraps" the outer task, returning a proxy
                  // for the inner one returned by GetSomething().
        .ContinueWith(task =>
        {
            // executes in UI thread.
            Prop = task.Result;
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
