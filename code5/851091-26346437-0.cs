    public static Task WithCancellation(this Task task,
    CancellationToken token)
    {
        return task.ContinueWith(t => t.GetAwaiter().GetResult(), token, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    }
    
    public static Task<T> WithCancellation<T>(this Task<T> task,
    CancellationToken token)
    {
        return task.ContinueWith(t => t.GetAwaiter().GetResult(), token, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
    }
