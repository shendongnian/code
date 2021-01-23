    class FilterDefinitionForCollectionPropertyValues<T>:FilterDefinition, IUserFilter
    {
    
    //This guy just points to a collection property
    public Expression<Func<UserProfile, IEnumerable<T>>> CollectionSelector { get; set; }
    // This one points to a property of a member of that collection.
    public Expression<Func<T, string>> CollectionPropertySelector { get; set; }
    
    
    //This one does the heavy work of building a predicate based on a collection,   
    //it's member property, operation type and a valaue
    public System.Linq.Expressions.Expression<Func<Profile.UserProfile, bool>> GetFilterPredicateFor(FilterOperations operation, string value)
    {
        var getExpressionBody = CollectionPropertySelector.Body as MemberExpression;
        if (getExpressionBody == null)
        {
            throw new Exception("getExpressionBody is not MemberExpression: " + CollectionPropertySelector.Body);
        }
    
        var propertyParameter = CollectionPropertySelector.Parameters[0];
        var collectionParameter = CollectionSelector.Parameters[0];
        var left = CollectionPropertySelector.Body;
        var right = Expression.Constant(value);
    
        // this is so far hardcoded, but might be changed later based on operation type  
        // as well as a "method" below
        var innerLambda = Expression.Equal(left, right);
    
        Expression<Func<T, bool>> innerFunction = Expression.Lambda<Func<T, bool>>(innerLambda, propertyParameter);
        // this is hadrcoded again, but maybe changed later when other type of operation will be needed
        var method = typeof(Enumerable).GetMethods().Where(m => m.Name == "Any" && m.GetParameters().Length == 2).Single().MakeGenericMethod(typeof(T));
    
        var outerLambda = Expression.Call(method, Expression.Property(collectionParameter, (CollectionSelector.Body as MemberExpression).Member as System.Reflection.PropertyInfo), innerFunction);
    
        var result = Expression.Lambda<Func<UserProfile, bool>>(outerLambda, collectionParameter);
    
        return result;
    
    }
    
    }
