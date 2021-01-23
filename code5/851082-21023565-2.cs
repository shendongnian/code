    public static async Task<TResult> WhenNotCanceled<TResult>(this Task<TResult> mainTask, CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled) {
            return await mainTask.ConfigureAwait(false);
        }
        cancellationToken.ThrowIfCancellationRequested();
        
        Task<TResult> completedTask;
        var cancellationTaskSource = new TaskCompletionSource<TResult>();
        using (cancellationToken.Register(() => cancellationTaskSource.TrySetCanceled(), useSynchronizationContext: false)
            completedTask = await Task.WhenAny(mainTask, cancellationTaskSource.Task).ConfigureAwait(false);
        return await completedTask.ConfigureAwait(false);
    }
    public static async Task WhenNotCanceled(this Task mainTask, CancellationToken cancellationToken)
    {
        if (!cancellationToken.CanBeCanceled) {
            await mainTask.ConfigureAwait(false);
            return;
        }
        cancellationToken.ThrowIfCancellationRequested();
        
        Task completedTask;
        var cancellationTaskSource = new TaskCompletionSource<object>();
        using (cancellationToken.Register(() => cancellationTaskSource.TrySetCanceled(), useSynchronizationContext: false)
            completedTask = await Task.WhenAny(mainTask, cancellationTaskSource.Task).ConfigureAwait(false);
        await completedTask.ConfigureAwait(false);
        return;
    }
