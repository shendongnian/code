    public static class Utility
    {
    	public static Expression<Func<TSource, object>> GetExpressionForProp<TSource>(this TSource source, string propertyName)
    	{
    		var param = Expression.Parameter(typeof(TSource), "x");
    		Expression conversion = Expression.Convert(Expression.Property(param, propertyName), typeof(object));
    		return Expression.Lambda<Func<TSource, object>>(conversion, param);
    	}
    
    	public static IOrderedQueryable<TSource> OrderByProp<TSource>(this IQueryable<TSource> source, string propertyName) 
    		where TSource : class, new()
    	{
    		return source.OrderBy(new TSource().GetExpressionForProp(propertyName));
    
    		//or comment where TSource : class, new() and
    		//var param = Expression.Parameter(typeof(TSource), "x");
    		//Expression conversion = Expression.Convert(Expression.Property(param, propertyName), typeof(object));
    		//var shortExpression = Expression.Lambda<Func<TSource, object>>(conversion, param);
    		//return source.OrderBy(shortExpression);
    	}
    }
