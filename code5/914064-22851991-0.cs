    static bool WaitAll(Task[] tasks, int timeout, CancellationToken token)
    {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
        var helperTasks = tasks.Select(task => 
            task.ContinueWith(t => {
                if (t.IsFaulted) cts.Cancel();
                return t; 
            }, 
            cts.Token, 
            TaskContinuationOptions.ExecuteSynchronously, 
            TaskScheduler.Current).Unwrap());
        return Task.WaitAll(helperTasks.ToArray(), timeout, cts.Token);
    }
