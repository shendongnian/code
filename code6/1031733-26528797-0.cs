    public static Task<TResult> RunAsync<TResult>(this SynchronizationContext context, Func<Task<TResult>> func)
    {
        var tcs = new TaskCompletionSource<TResult>();
        context.Post(async _ =>
        {
            try
            {
                tcs.TrySetResult(await func());
            }
            catch (OperationCanceledException)
            {
                tcs.TrySetCanceled();
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        }, null);
        return tcs.Task;
    }
