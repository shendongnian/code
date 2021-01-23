    public Type GetNullable(Type type)
    {
    	if (type == typeof(Nullable<>))
    		return  type.GetType();
    		
    	if(type == typeof(int))
    		type = typeof(int?);
    	else if(type == typeof(bool))
    		type = typeof(bool?);
    	else if(type == typeof(float))
    		type = typeof(float?);		
    	// etc. you  will have to build out every type you want.
    	
    	return type;
    }
    
    public Expression<Func<VwAssignmentActivities, bool>> GetIsNullExpressionEquals(string propName, Type value)
    {		
    	var item = Expression.Parameter(typeof(VwAssignmentActivities), "item");
    	var prop = Expression.Convert(Expression.Property(item, propName), GetNullable(value));
    	
    	Expression body = Expression.Equal(prop, Expression.Constant(null, prop.Type));
    	
    	return Expression.Lambda<Func<VwAssignmentActivities, bool>>(body, item);
    }
