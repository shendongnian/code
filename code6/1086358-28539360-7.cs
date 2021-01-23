    public static class TaskExt
    {
        class SimpleSynchronizationContext : SynchronizationContext
        {
            internal static readonly SimpleSynchronizationContext Instance = new SimpleSynchronizationContext();
        };
        public static void TrySetResult<TResult>(this TaskCompletionSource<TResult> @this, TResult result, bool asyncAwaitContinuations)
        {
            if (!asyncAwaitContinuations)
            {
                @this.TrySetResult(result);
                return;
            }
            var sc = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(SimpleSynchronizationContext.Instance);
            try
            {
                @this.TrySetResult(result);
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(sc);
            }
        }
    }
