    private Expression<Func<TArg, bool>> CreatePredicate<TArg, TPredicateField>(string fieldName, TPredicateField value)
    {
    	ParameterExpression parameter = Expression.Parameter(typeof(TArg), "o");
    	
    	MemberExpression memberExpression =	Expression.Property(parameter, fieldName);
    
    	var condition = Expression.Equal(memberExpression, Expression.Constant(value));
    	var lambda = Expression.Lambda<Func<TArg, bool>>(condition, parameter);
    	
    	return lambda;
    }
    
    private Expression<Func<TArg, TPredicateField>> CreateSelector<TArg, TPredicateField>(string fieldName)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(TArg), "o");
        Expression propertyExpr = Expression.Property(parameter, fieldName);
        
        var lambda = Expression.Lambda<Func<TArg, TPredicateField>>(propertyExpr, parameter);
        
        return lambda;
    }
    
    public TSelectorField GetModStamp<TEntity, TPredicateField, TSelectorField>(TPredicateField id) where TEntity : class
    {
        using (var ctx = new OnTheFlyEntities("Data Source=(local);Initial Catalog=AscensionBO;Integrated Security=True;MultipleActiveResultSets=True"))
        {
            var predicate = CreatePredicate<TEntity, TPredicateField>("Id", id);
            var selector = CreateSelector<TEntity, TSelectorField>("ModStamp");
            
            TSelectorField item = ctx.Set<TEntity>().Where(predicate).Select(selector).SingleOrDefault();
            
            return item;
        }
    }
