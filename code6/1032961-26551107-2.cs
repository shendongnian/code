    public static string GetKeyField(Type type)
    {
        var allProperties = type.GetProperties();
        var keyProperty = allProperties.SingleOrDefault(p => p.IsDefined(typeof(KeyAttribute)));
        return keyProperty != null ? keyProperty.Name : null;
    }
    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string orderBy)
    {
        return source.GetOrderByQuery(orderBy, "OrderBy");
    }
    public static IQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string orderBy)
    {
        return source.GetOrderByQuery(orderBy, "OrderByDescending");
    }
    private static IQueryable<T> GetOrderByQuery<T>(this IQueryable<T> source, string orderBy, string methodName)
        {
            var sourceType = typeof(T);
            var property = sourceType.GetProperty(orderBy);
            var parameterExpression = Expression.Parameter(sourceType, "x");
            var getPropertyExpression = Expression.MakeMemberAccess(parameterExpression, property);
            var orderByExpression = Expression.Lambda(getPropertyExpression, parameterExpression);
            var resultExpression = Expression.Call(typeof(Queryable), methodName,
                                                   new[] { sourceType, property.PropertyType }, source.Expression,
                                                   orderByExpression);
            return source.Provider.CreateQuery<T>(resultExpression);
        }
