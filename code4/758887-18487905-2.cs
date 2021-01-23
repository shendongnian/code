    public static IEnumerable<Type> GetDirectDescendants(this Type t)
    {
        if (!t.IsClass)
            throw new Exception(t + " is not a class");
        return t.Assembly.GetTypes().Where(x => x.BaseType == t);
    }
