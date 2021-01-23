    public static TResult ValueOrDefault<T, TResult>(this T obj, System.Func<T, TResult> getter)
    {
        return obj != null ? getter(obj) : default(TResult);
    }
    public static TResult ValueOrDefault<T, TResult>(this T obj, System.Func<T, TResult> getter, TResult Default)
    {
        return obj != null ? getter(obj) : Default;
    }
