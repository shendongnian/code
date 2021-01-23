    public static class TaskExt
    {
        public static async Task<TEventArgs> FromEvent<TEventHandler, TEventArgs>(
            Func<Action<TEventArgs>, Action, Action<Exception>, TEventHandler> getHandler,
            Action<TEventHandler> subscribe,
            Action action,
            Action<TEventHandler> unsubscribe,
            CancellationToken token) where TEventHandler : class
        {
            var tcs = new TaskCompletionSource<TEventArgs>();
            TEventHandler handler = getHandler(
                args => tcs.TrySetResult(args),
                () => tcs.TrySetCanceled(),
                ex => tcs.TrySetException(ex));
            subscribe(handler);
            try
            {
                using (token.Register(() => tcs.TrySetCanceled()))
                {
                    action();
                    return await tcs.Task;
                }
            }
            finally
            {
                unsubscribe(handler);
            }
        }
    }
