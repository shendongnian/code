    public static class Extensions
    {
    	/// <summary>
    	/// Intended for merging an enumeration of flags enum into a single value.
    	/// </summary>
    	public static TEnum Merge<TEnum>(this IEnumerable<TEnum> values)
    		where TEnum : struct, IConvertible
    	{
    		var type = typeof(TEnum);
    		if (!type.IsEnum)
    			throw new InvalidOperationException($"{type} is not an enum type.");
    
    		return values.DefaultIfEmpty(default).Aggregate(Operator<TEnum>.Or);
    	}
    
    	static class Operator<T>
    	{
    		private static readonly Lazy<Func<T, T, T>> LazyOr;
    		private static readonly Lazy<Func<T, T, T>> LazyAnd;
    
    		public static Func<T, T, T> Or => LazyOr.Value;
    		public static Func<T, T, T> And => LazyAnd.Value;
    
    		static Operator()
    		{
    			var enumType = typeof(T);
    			var underType = enumType.GetEnumUnderlyingType();
    			var leftParam = Expression.Parameter(enumType, "left");
    			var rightParam = Expression.Parameter(enumType, "right");
    			var leftCast = Expression.ConvertChecked(leftParam, underType);
    			var rightCast = Expression.ConvertChecked(rightParam, underType);
    
    			LazyOr = new Lazy<Func<T, T, T>>(() =>
    			{
    				var or = Expression.Or(leftCast, rightCast);
    				var resultCast = Expression.ConvertChecked(or, enumType);
    				var l = Expression.Lambda<Func<T, T, T>>(resultCast, leftParam, rightParam);
    				return l.Compile();
    			});
    
    			LazyAnd = new Lazy<Func<T, T, T>>(() =>
    			{
    				var and = Expression.And(leftCast, rightCast);
    				var resultCast = Expression.ConvertChecked(and, enumType);
    				var l = Expression.Lambda<Func<T, T, T>>(resultCast, leftParam, rightParam);
    				return l.Compile();
    			});
    		}
    	}
    }
