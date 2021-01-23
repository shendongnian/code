    public static ???? castAndReturn(object item, Type type)
    {
        var p = Expression.Parameter(typeof(object), "i");
        var c = Expression.Convert(p, type);
        var ex = Expression.Lambda<Func<object, ????>>(c, p).Compile();
        return ex(item);
    }
