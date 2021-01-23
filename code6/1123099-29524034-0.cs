    public static class Combinator
    {
        public static Func<TInput, TResult> Y<TInput, TResult>(Func<Func<TInput,TResult>, TInput, TResult> function)
        {
            return input => function(Y(function), input);
        }
    }
