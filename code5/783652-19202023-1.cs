    public static IQueryable<IGrouping<TProperty,TEntity>> GroupBy<TEntity, TProperty>(
        IQueryable<TEntity> source,
        string fieldName) 
        where TEntity : class, IDataEntity
    {
        if (string.IsNullOrEmpty(fieldName))
        {
            return new List<IGrouping<TProperty, TEntity>>().AsQueryable();
        }
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var propertyAccess = Expression.Property(parameter, fieldName);
		var lambda = Expression.Lambda<Func<TEntity, TProperty>>(propertyAccess, parameter);
		var result = source.GroupBy (lambda);
		return result;
    }
