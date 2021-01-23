    static Expression<Func<TSource, bool>> GetWhereExpression<TSource>(string value)
    {
        var param = Expression.Parameter(typeof(TSource));
        var val = Expression.Constant(value);
        var expression = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
        foreach(var prop in typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if(prop.PropertyType == typeof(string))
            {
                expression = Expression.AndAlso(expression,
                                Expression.Equal(
                                    Expression.Property(param, prop),
                                    val
                                ));
            }
        }
        return Expression.Lambda<Func<TSource, bool>>(expression, param);
    }
