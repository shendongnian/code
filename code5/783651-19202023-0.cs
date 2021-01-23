    public static IQueryable GroupBy<TEntity>(
        IQueryable<TEntity> source,
        string fieldName) 
        where TEntity : class, IDataEntity
    {
        if (string.IsNullOrEmpty(fieldName))
        {
            return new List<IGrouping<object, TEntity>>().AsQueryable();
        }
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var propertyAccess = Expression.Property(parameter, fieldName);
		var lambda = Expression.Lambda(propertyAccess, parameter);
		var groupExpression = Expression.Call(
			typeof(Queryable).GetMethods()
							.First (x => x.Name == "GroupBy")
							.MakeGenericMethod(new[]{ typeof(TEntity), propertyAccess.Type }),
			source.Expression,
			lambda);
   		var result = source.Provider.CreateQuery(groupExpression);
		return result;
    }
