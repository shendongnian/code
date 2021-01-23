    public static void WaitUnlessFault( Task[] tasks, CancellationToken token )
    {
        var cts = CancellationTokenSource.CreateLinkedTokenSource(token);
        foreach ( var task in tasks ) {
            task.ContinueWith(t =>
            {
                if ( t.IsFaulted ) cts.Cancel();
            },
            cts.Token,
            TaskContinuationOptions.ExecuteSynchronously,
            TaskScheduler.Current);
        }
        try {
            Task.WaitAll(tasks, cts.Token);
        }
        catch ( OperationCanceledException ex ) {
            var faultedTaskEx = tasks.Where(t => t.IsFaulted)
                .Select(t => t.Exception)
                .FirstOrDefault();
            if ( faultedTaskEx != null )
                throw faultedTaskEx;
            else
                throw;
        }
    }
