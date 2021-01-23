    protected override void PersistUpdateInternal(IStoreObject storeObject)
    {
    	if (storeObject == null)
    		throw new NullReferenceException("storeObject");
    
    	var original = GetOriginalEntity(storeObject);
    	if (original != null)
    	{
    		var entry = _context.Entry(original);
    		entry.CurrentValues.SetValues(storeObject);
    	}
    	else
    	{
    		GetDbSet().Attach((T)storeObject);
    		_context.Entry(storeObject).State = EntityState.Modified;
    	}
    
    }
    protected T GetOriginalEntity(IStoreObject storeObject)
    {
    	var objectContext = ((IObjectContextAdapter)_context).ObjectContext;
    	var objectSet = objectContext.CreateObjectSet<T>();
    
    	var entitySet = objectSet.EntitySet;
    	var keyMembers = entitySet.ElementType.KeyMembers;
    
    	Expression<Func<T, bool>> predicate = i => true;
    	foreach (var keyMember in keyMembers)
    	{
    		var propertyInfo = typeof(T).GetProperty(keyMember.Name);
    
    		var pe = Expression.Parameter(typeof(T), "i");
    		var left = Expression.PropertyOrField(pe, keyMember.Name);
    		var right = Expression.Constant(propertyInfo.GetValue(storeObject), propertyInfo.PropertyType);
    		var body = Expression.Equal(left, right);
    		var whereExpression = Expression.Lambda<Func<T, bool>>(body, pe);
    		predicate = predicate.And(whereExpression);
    	}
    
    	var original = GetDbSet().Local.FirstOrDefault(predicate.Compile());
    
    	return original;
    }
