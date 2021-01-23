    public static Task AsTask(this CancellationToken cancellationToken)
    {
        var tcs = new TaskCompletionSource();
        cancellationToken.Register(() => tcs.TrySetCanceled(),
            useSynchronizationContext: false);
        return tcs.Task;
    }
