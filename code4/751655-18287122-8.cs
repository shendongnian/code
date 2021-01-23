    public static IOrderedQueryable<T> OrderBy<T, K>(this IQueryable<T> items, LambdaExpression expression, OrderDirection? direction)
    {
    	if (direction == OrderDirection.Ascending || !direction.HasValue)
    		return items.OrderBy(expression as Expression<Func<T, K>>);
    	else
    		return items.OrderByDescending(expression as Expression<Func<T, K>>);
    }
    
    public static IQueryable<T> ThenBy<T, K>(this IOrderedQueryable<T> items, LambdaExpression expression, OrderDirection? direction)
    {
    	if (direction == OrderDirection.Ascending || !direction.HasValue)
    		return items.ThenBy(expression as Expression<Func<T, K>>);
    	else
    		return items.ThenByDescending(expression as Expression<Func<T, K>>);
    }
