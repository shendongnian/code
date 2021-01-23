    public static void Use<T>(this T obj, Action<T> action)
        where T : class
    {
        if(obj != null) action(obj);
    }
