    public static class TaskExtensionMethods
    {
        public static Task<TResult> OrWhenCancelled<TResult>(this Task<TResult> mainTask, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
                return mainTask;
            return OrWhenCancelled_(mainTask, cancellationToken);
        }
        private static async Task<TResult> OrWhenCancelled_<TResult>(this Task<TResult> mainTask, CancellationToken cancellationToken)
        {
            Task cancellationTask = mainTask.ContinueWith(t => { }, cancellationToken, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnCanceled, TaskScheduler.Default);
            await Task.WhenAny(mainTask, cancellationTask).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            return await mainTask.ConfigureAwait(false);
        }
        public static Task OrWhenCancelled(this Task mainTask, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
                return mainTask;
            return OrWhenCancelled_(mainTask, cancellationToken);
        }
        private static async Task OrWhenCancelled_(this Task mainTask, CancellationToken cancellationToken)
        {
            Task cancellationTask = mainTask.ContinueWith(t => { }, cancellationToken, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnCanceled, TaskScheduler.Default);
            await Task.WhenAny(mainTask, cancellationTask).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            await mainTask;
        }
    }
