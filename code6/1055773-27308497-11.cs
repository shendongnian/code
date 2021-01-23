    public static class TaskExtensions
    {
        public static Task<TResult> Run<TResult>(Func<CancellationToken, TResult> function, CancellationToken token)
        {
            Func<TResult> wrappedFunction = () => function(token);
            return Task.Run(wrappedFunction, token);
        }
    }
