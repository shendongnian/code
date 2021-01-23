    public static Func<Object, Object> CompilePropGetter(PropertyInfo info)
    {
        ParameterExpression instance = Expression.Parameter(typeof(object));
        var propExpr = Expression.Property(Expression.Convert(instance, info.DeclaringType), info);
        var castExpr = Expression.Convert(propExpr, typeof(object));
        var body = Expression.Lambda<Func<object, object>>(castExpr, instance);
        return body.Compile();
    }
