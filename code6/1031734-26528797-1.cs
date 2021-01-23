    public static Task<TResult> ExecuteOnCurrentSynchronizationContextAsync<TResult>(
        this RetryPolicy retryPolicy, 
        Func<Task<TResult>> taskFunc)
    {
        var context = SynchronizationContext.Current ?? new SynchronizationContext();
        return retryPolicy.ExecuteAsync(() => context.RunAsync(taskFunc));
    }
