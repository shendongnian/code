    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
    {
        return ApplyOrder<T>(source, property, "OrderBy");
    }
    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
    {
        return ApplyOrder<T>(source, property, "OrderByDescending");
    }
    public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
    {
        return ApplyOrder<T>(source, property, "ThenBy");
    }
    public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
    {
        return ApplyOrder<T>(source, property, "ThenByDescending");
    }
    static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName) {
        string[] props = property.Split('.');
        Type elementType = source.ElementType;
        Type type = elementType;
        ParameterExpression arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        foreach(string prop in props) {
            // use reflection (not ComponentModel) to mirror LINQ
            PropertyInfo pi = type.GetProperty(prop);
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
        }
        Type delegateType = typeof(Func<,>).MakeGenericType(elementType, type);
        LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);
        object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                        && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2
                        && method.GetParameters().Length == 2)
                .MakeGenericMethod(elementType, type)
                .Invoke(null, new object[] {source, lambda});
        return (IOrderedQueryable<T>)result;
    }
