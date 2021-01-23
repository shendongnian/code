    public static IEnumerable<Type> GetLastDescendants(this Type t)
    {
        if (!t.IsClass)
            throw new Exception(t + " is not a class");
        var subTypes = t.Assembly.GetTypes().Where(x => x.IsSubclassOf(t)).ToArray();
        return subTypes.Where(x => subTypes.All(y => y.BaseType != x));
    }
