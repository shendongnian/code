    public static IQueryable<T> WithId<T>(this IQueryable<T> entities,
        Expression<Func<T, int>> propertySelector, ICollection<int> ids)
    {
        var property =
            (PropertyInfo)((MemberExpression)propertySelector.Body).Member;
        ParameterExpression parameter = Expression.Parameter(typeof(T));
            
        var expression = Expression.Lambda<Func<T, bool>>(
            Expression.Call(
                Expression.Constant(ids),
                typeof(ICollection<int>).GetMethod("Contains"), 
                Expression.Property(parameter, property)), 
            parameter);
        return entities.Where(expression);
    }
