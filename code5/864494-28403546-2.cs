	private class InterceptingQueryProvider : IQueryProvider
	{
		private readonly IQueryProvider _actualQueryProvider;
		public InterceptingQueryProvider(IQueryProvider actualQueryProvider)
		{
			_actualQueryProvider = actualQueryProvider;
		}
		public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
		{
			var specializedExpression = QueryExpressionSpecializer.Specialize(expression);
			return _actualQueryProvider.CreateQuery<TElement>(specializedExpression);
		}
		public IQueryable CreateQuery(Expression expression)
		{
			var specializedExpression = QueryExpressionSpecializer.Specialize(expression);
			return _actualQueryProvider.CreateQuery(specializedExpression);
		}
		public TResult Execute<TResult>(Expression expression)
		{
			return _actualQueryProvider.Execute<TResult>(expression);
		}
		public object Execute(Expression expression)
		{
			return _actualQueryProvider.Execute(expression);
		}
	}
