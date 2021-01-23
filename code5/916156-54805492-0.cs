    /// <summary>
    /// Creates lambda expression predicate: (TEntity entity) => collection.Contains(entity.property)
    /// </summary>
    public static Expression<Func<TEntity, bool>> ContainsExpression<TEntity, TProperty, TCollection>(
        this TCollection collection, 
        Expression<Func<TEntity, TProperty>> property
    )
        where TCollection : ICollection<TProperty>
    {
        // contains method
        MethodInfo containsMethod = typeof(TCollection).GetMethod(nameof(collection.Contains), new[] { typeof(TProperty) });
        // your value
        ConstantExpression collectionInstanceExpression = Expression.Constant(collection);
        // call the contains from a property and apply the value
        var containsValueExpression = Expression.Call(collectionInstanceExpression, containsMethod, property.Body);
        // create your final lambda Expression
        Expression<Func<TEntity, bool>> result = Expression.Lambda<Func<TEntity, bool>>(containsValueExpression, property.Parameters[0]);
        return result;
    }
