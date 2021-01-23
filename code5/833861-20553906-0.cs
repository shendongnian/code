    public static Task AddCancellation(this Task task, CancellationToken token)
    {
        return Task.WhenAny(task, task.ContinueWith(t => { }, token))
            .Unwrap();
    }
    public static Task<T> AddCancellation<T>(this Task<T> task, 
        CancellationToken token)
    {
        return Task.WhenAny(task, task.ContinueWith(t => t.Result, token))
            .Unwrap();
    }
