    static IQueryable<T> WhereColumnContains<T>(this IQueryable<T> source, Expression<Func<T, string>> selector, string search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return source;
        }
        Expression<Func<T, bool>> expression;
        search = search.Trim();
        var filterStartsWith = search.EndsWith("*");
        var filterEndsWith = search.StartsWith("*");
        if (filterEndsWith) search = search.Substring(1);
        if (filterStartsWith)
        {
            search = search.Substring(0, search.Length - 1);
            if (filterEndsWith)
            {
                var parameter = Expression.Parameter(typeof(T), "parameter");
                expression = Expression.Lambda<Func<T, bool>>(
                    Expression.Call(Expression.Invoke(selector, parameter), typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(search)),
                    parameter);
            }
            else
            {
                var parameter = Expression.Parameter(typeof(T), "parameter");
                expression = Expression.Lambda<Func<T, bool>>(
                    Expression.Call(Expression.Invoke(selector, parameter), typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), Expression.Constant(search)),
                    parameter);
            }
        }
        else
        {
            if (filterEndsWith)
            {
                var parameter = Expression.Parameter(typeof(T), "parameter");
                expression = Expression.Lambda<Func<T, bool>>(
                    Expression.Call(Expression.Invoke(selector, parameter), typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), Expression.Constant(search)),
                    parameter);
            }
            else
            {
                var parameter = Expression.Parameter(typeof(T), "parameter");
                expression = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(Expression.Invoke(selector, parameter), Expression.Constant(search)),
                    parameter);
            }
        }
        return source.Where(expression);
    }
