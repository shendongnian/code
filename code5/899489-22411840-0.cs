    private static Tuple<Expression, Type> GetSelector<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        Expression body = Expression.Property(parameter, propertyName);
        return Tuple.Create(Expression.Lambda(body, parameter) as Expression
            , body.Type);
    }
    private static IOrderedQueryable<T> OrderBy<T>(IQueryable<T> query,
        string property, bool ascending)
    {
        var selector = GetSelector<T>(property);
        Type[] argumentTypes = new[] { typeof(T), selector.Item2 };
        var methodName = ascending ? "OrderBy" : "OrderByDescending";
        var orderByMethod = typeof(Queryable).GetMethods()
            .First(method => method.Name == methodName
                && method.GetParameters().Count() == 2)
                .MakeGenericMethod(argumentTypes);
        return (IOrderedQueryable<T>)
            orderByMethod.Invoke(null, new object[] { query, selector.Item1 });
    }
    private static IOrderedQueryable<T> ThenBy<T>(IOrderedQueryable<T> query,
        string property, bool ascending)
    {
        var selector = GetSelector<T>(property);
        Type[] argumentTypes = new[] { typeof(T), selector.Item2 };
        var methodName = ascending ? "ThenBy" : "ThenByDescending";
        var orderByMethod = typeof(Queryable).GetMethods()
            .First(method => method.Name == methodName
                && method.GetParameters().Count() == 2)
                .MakeGenericMethod(argumentTypes);
        return (IOrderedQueryable<T>)
            orderByMethod.Invoke(null, new object[] { query, selector.Item1 });
    }
    public static IOrderedQueryable<T> OrderBy<T>(
        this IQueryable<T> query,
        string property)
    {
        return OrderBy<T>(query, property, true);
    }
    public static IOrderedQueryable<T> OrderByDescending<T>(
        this IQueryable<T> query,
        string property)
    {
        return OrderBy<T>(query, property, false);
    }
    public static IOrderedQueryable<T> ThenBy<T>(
        this IOrderedQueryable<T> query,
        string property)
    {
        return ThenBy<T>(query, property, true);
    }
    public static IOrderedQueryable<T> ThenByDescending<T>(
        this IOrderedQueryable<T> query,
        string property)
    {
        return ThenBy<T>(query, property, false);
    }
