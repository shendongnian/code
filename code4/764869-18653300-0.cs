	public static class EqualityHelper
	{
		private ConcurrentDictionary<Type, object> _cache = new ConcurrentDictionary<Type, object>();
		public bool AreEqual<T>(T left, T right)
		{
			var equality = (Func<T,T,bool>)_cache.GetOrAdd(typeof(T), CreateEquality<T>());
			return equality(left, right);
		}
		
		private Func<T, T, bool> CreateEquality<T>()
		{
			var left = Expression.Parameter(typeof(T));
			var right = Expression.Parameter(typeof(T));
			var properties = from x in typeof(T).GetProperties()
							where x.GetIndexParameters().Any() == false
							select x;
			var expressions = from p in properties
							select Expression.Equal(
								Expression.Property(left, p),
								Expression.Property(right, p));
			var body = expressions.Aggregate(Expression.AndAlso);
			var lambda = Expression.Lambda<Func<T,T,bool>>(body, new [] {left, right});
			return lambda.Compile();
		}
	}
