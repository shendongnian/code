    //
    // Use: await LongRunningTask.Then(DoSomethingMore, cancellationToken)
    //
    public static class TaskExt
    {
        public static async Task Then(
            this Task antecedent, Action continuation, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            var tcs = new TaskCompletionSource<Empty>();
            using (token.Register(() => tcs.TrySetCanceled()))
                await Task.WhenAny(antecedent, tcs.Task);
            token.ThrowIfCancellationRequested();
            continuation();
        }
        struct Empty { };
    }
