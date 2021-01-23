    public static Task WithCancellation(this Task task
        , CancellationToken token)
    {
        return task.ContinueWith(t => t.GetAwaiter().GetResult(), token);
    }
    public static Task<T> WithCancellation<T>(this Task<T> task
        , CancellationToken token)
    {
        return task.ContinueWith(t => t.GetAwaiter().GetResult(), token);
    }
