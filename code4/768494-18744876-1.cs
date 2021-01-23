    public static Expression<Func<T, bool>> SearchAllFields<T>(string searchText)
    {
        var t = Expression.Parameter(typeof(T));
        Expression body = Expression.Constant(false);
        var containsMethod = typeof(string).GetMethod("Contains"
            , new[] { typeof(string) });
        var toStringMethod = typeof(object).GetMethod("ToString");
        var stringProperties = typeof(T).GetProperties()
            .Where(property => property.PropertyType == typeof(string));
        foreach (var property in stringProperties)
        {
            var stringValue = Expression.Call(Expression.Property(t, property.Name),
                toStringMethod);
            var nextExpression = Expression.Call(stringValue,
                containsMethod,
                Expression.Constant(searchText));
            body = Expression.OrElse(body, nextExpression);
        }
        return Expression.Lambda<Func<T, bool>>(body, t);
    }
