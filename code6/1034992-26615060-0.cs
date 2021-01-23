    public static ParallelQuery<TFinal> SelectAll<T, TResult1, TResult2, TFinal>(
        this ParallelQuery<T> query,
        Func<T, TResult1> selector1,
        Func<T, TResult2> selector2,
        Func<TResult1, TResult2, TFinal> resultAggregator)
    {
        return query.Select(item =>
        {
            var result1 = Task.Run(() => selector1(item));
            var result2 = Task.Run(() => selector2(item));
            return resultAggregator(result1.Result, result2.Result);
        });
    }
