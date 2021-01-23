    static bool WaitAll(Task[] tasks, int timeout, CancellationToken token)
    {
        using (var cts = CancellationTokenSource.CreateLinkedTokenSource(token))
        {
            var proxyTasks = tasks.Select(task => 
                task.ContinueWith(t => {
                    if (t.IsFaulted) cts.Cancel();
                    return t; 
                }, 
                cts.Token, 
                TaskContinuationOptions.ExecuteSynchronously, 
                TaskScheduler.Current).Unwrap());
    
            return Task.WaitAll(proxyTasks.ToArray(), timeout, cts.Token);
        }
    }
