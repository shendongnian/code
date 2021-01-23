    public static TResult Access<TSource, TResult>(
       TSource obj, Func<TSource, TResult> selector, TResult defaultIfNull)
       where TSource : class
    {
        TResult result;
        try
        {
            result = selector(obj);
        }
        catch ( NullReferenceException)
        {
            result = defaultIfNull;
        }
        return result;
    }
