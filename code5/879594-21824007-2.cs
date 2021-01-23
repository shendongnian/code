    public static class FuncExtensions
    {
        public static TResult EndInvoke<T, TResult>(this Func<T, TResult> asyncCaller, IAsyncResult asyncResult)
        {
            // ...
        }
    }
