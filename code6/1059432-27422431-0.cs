    public static T GetAttribute<T>(this PropertyInfo pi) where T : Attribute
    {
        var attr = pi.GetCustomAttribute<T>();
        if (attr != null) return attr;
        var type = pi.DeclaringType;
        var interfaces = type.GetInterfaces();
        foreach(var i in interfaces)
        {
            var p = i.GetProperties().FirstOrDefault(x => x.GetCustomAttribute<T>() != null);
            if (p != null)
                return p.GetCustomAttribute<T>();
        }
        return null;
    }
