    public static class MaybeMonadExtensions
    {
        public static TResult GetIfNotNull<TInput, TResult>(this TInput o, Func<TInput, TResult> evaluator)
            where TResult : class
            where TInput : class
        {
            return o == null ? null : evaluator(o);
        }
    }
