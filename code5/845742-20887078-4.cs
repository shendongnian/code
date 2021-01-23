    	public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> query, FilterContainer filters)
		{
			Expression expression = GetSingleExpression<TEntity>(filters, parameters);
			var lambda = Expression.Lambda<Func<TEntity, bool>>(expression, parameters);
			return query.Where(lambda);
		}
