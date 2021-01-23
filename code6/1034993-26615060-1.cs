    public static ParallelQuery<TFinal> SelectAll<T, TResult1, TResult2, TResult3, TFinal>(
        this ParallelQuery<T> query,
        Func<T, TResult1> selector1,
        Func<T, TResult2> selector2,
        Func<T, TResult3> selector3,
        Func<TResult1, TResult2, TResult3, TFinal> resultAggregator)
    {
        return query.Select(item =>
        {
            var result1 = Task.Run(() => selector1(item));
            var result2 = Task.Run(() => selector2(item));
            var result3 = Task.Run(() => selector3(item));
            return resultAggregator(
                result1.Result,
                result2.Result,
                result3.Result);
        });
    }
