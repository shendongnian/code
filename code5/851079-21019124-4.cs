    public static class TaskExt
    {
        /// <summary>
        /// Use: await LongRunningTask.Then(DoSomethingMore, cancellationToken)
        /// </summary>
        public static async Task Then(
            this Task antecedent, Action continuation, CancellationToken token)
        {
            await antecedent.When(token);
            continuation();
        }
        /// <summary>
        /// Use: await LongRunningTask.When(cancellationToken)
        /// </summary>
        public static async Task When(
            this Task antecedent, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            var tcs = new TaskCompletionSource<Empty>();
            using (token.Register(() => tcs.TrySetCanceled()))
                await Task.WhenAny(antecedent, tcs.Task);
            token.ThrowIfCancellationRequested();
        }
        struct Empty { };
    }
