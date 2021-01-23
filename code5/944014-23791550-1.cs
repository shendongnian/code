    public static Type GetInnermost(Type t)
    {
        while(t.IsGenericType)
        {
            t = t.GetGenericArguments()[0];
        }
        return t;
    }
