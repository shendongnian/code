    public static string Enqueue<T>(System.Linq.Expressions.Expression<Func<T, string>> methodCall)
        where T: new()
    {
        T t = new T();
        Func<T, string> action = methodCall.Compile();
        return action(t);
    }
