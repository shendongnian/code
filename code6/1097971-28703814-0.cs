    public static Expression<Func<TEntity, bool>> GetPropertyEqualityExpression<TEntity, TProperty>(string propertyName, TProperty propertyValue)
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        var property = Expression.Property(parameter, propertyName, null);
        var equality = Expression.Equal(property, Expression.Constant(propertyValue));
        var lambda = Expression.Lambda<Func<TEntity, bool>>(equality, parameter);
        return lambda;
    }
