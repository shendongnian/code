    Task Process(CancellationToken cancellationToken)
    {
        var tArray = new List<Task>();
        var tArrayLock = new Object();
    
        var task = Task.Run(() =>
        {
            cancellationToken.ThrowIfCancellationRequested();
            //do some work here
            return MainTaskRoutine(cancellationToken);
        }, cancellationToken);
    
        // add the task to the array,
        // use lock as we may remove tasks from this array on a different thread
        lock (tArrayLock)
            tArray.Add(task);
        task.ContinueWith((antecedentTask) =>
        {
            if (antecedentTask.IsCanceled || antecedentTask.IsFaulted)
            {
                // handle cancellation or exception inside the task
                // ...
            }
            // remove task from the array,
            // could be on a different thread from the Process's thread, use lock
            lock (tArrayLock)
                tArray.Remove(antecedentTask);
        }, TaskContinuationOptions.ExecuteSynchronously);
    
        // add more tasks like the above
        // ...
    
        // Return aggregated task
        Task[] allTasks = null;
        lock (tArrayLock)
            allTasks = tArray.ToArray();
        return Task.WhenAll(allTasks);
    }
