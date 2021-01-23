    public static IQueryable<T> AnyFieldContains<T>(
        this IQueryable<T> query,
        string searchText)
    {
        return AnyFieldContains(query, searchText,
            typeof(T).GetProperties()
            .Select(prop => CreateSelector<T>(prop))
            .ToArray());
    }
    private static Expression<Func<T, string>> CreateSelector<T>(PropertyInfo prop)
    {
        var param = Expression.Parameter(typeof(T));
        Expression body = Expression.Property(param, prop);
        if (prop.PropertyType == typeof(decimal?))
            body = Expression.Call(body, typeof(SqlFunctions)
                .GetMethod("StringConvert", new[] { typeof(decimal?) }));
        else if (prop.PropertyType == typeof(double?))
            body = Expression.Call(body, typeof(SqlFunctions)
                .GetMethod("StringConvert", new[] { typeof(double?) }));
        return Expression.Lambda<Func<T, string>>(body, param);
    }
