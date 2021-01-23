    public struct Empty
    {
        public static readonly Empty Value = default(Empty);
    }
    public static class TaskExt
    {
        public static Task<Empty> Convert(this Task @this)
        {
            var cts = new CancellationTokenSource();
            return @this.ContinueWith(t =>
            {
                try
                {
                    // propagate exceptions without wrapping
                    t.GetAwaiter().GetResult();
                }
                catch (OperationCanceledException)
                {
                    // propogate cancellation
                    if (t.IsCanceled)
                        cts.Cancel();
                    else throw;
                }
                cts.Token.ThrowIfCancellationRequested();
                return Empty.Value;
            }, cts.Token, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Current);
        }
    }
