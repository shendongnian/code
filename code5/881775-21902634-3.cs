    ThreadPool.QueueUserWorkItem(x =>
    {
        var tcs = new TaskCompletionSource<int>();
        uiSynchronizationContext.Post(s => 
        {
            try
            {
                tcs.SetResult(Test());
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }, null);
        // observe the completion,
        // only if there's an error
        tcs.Task.ContinueWith(task =>
        {
            // handle the error on a pool thread
            Debug.Print(task.Exception.ToString());
        }, TaskContinuationOptions.OnlyOnFaulted);
    });
