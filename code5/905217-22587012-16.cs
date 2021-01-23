    public static class TaskExt
    {
        static readonly ConcurrentDictionary<Task, Thread> s_tcsTasks =
            new ConcurrentDictionary<Task, Thread>();
    
        // SetResultAsync
        static public void SetResultAsync<TResult>(
            this TaskCompletionSource<TResult> @this,
            TResult result)
        {
            s_tcsTasks.TryAdd(@this.Task, Thread.CurrentThread);
            try
            {
                @this.SetResult(result);
            }
            finally
            {
                Thread thread;
                s_tcsTasks.TryRemove(@this.Task, out thread);
            }
        }
    
        // ContinueWithAsync, TODO: more overrides
        static public Task ContinueWithAsync<TResult>(
            this Task<TResult> @this,
            Action<Task<TResult>> action,
            TaskContinuationOptions continuationOptions = TaskContinuationOptions.None)
        {
            return @this.ContinueWith((Func<Task<TResult>, Task>)(t =>
            {
                Thread thread = null;
                s_tcsTasks.TryGetValue(t, out thread);
                if (Thread.CurrentThread == thread)
                {
                    // same thread which called SetResultAsync, avoid potential deadlocks
    
                    // using thread pool
                    return Task.Run(() => action(t));
    
                    // not using thread pool (TaskCreationOptions.LongRunning creates a normal thread)
                    // return Task.Factory.StartNew(() => action(t), TaskCreationOptions.LongRunning);
                }
                else
                {
                    // continue on the same thread
                    var task = new Task(() => action(t));
                    task.RunSynchronously();
                    return Task.FromResult(task);
                }
            }), continuationOptions).Unwrap();
        }
    }
