    public static string Enqueue<T>(System.Linq.Expressions.Expression<Action<T>> methodCall)
        where T: new()
    {
        T t = new T();
        Action<T> action = methodCall.Compile();
        action(t);
        return "WHATEVER";
    }
