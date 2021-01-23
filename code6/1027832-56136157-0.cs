    public IEnumerable<T> SetOf<T>() where T : class
    {
    	var firstType = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
    		.FirstOrDefault(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    	if (firstType == null) return new List<T>();
    
    	var dbSetMethodInfo = typeof(DbContext).GetMethod("Set");
    	var dbSet = dbSetMethodInfo.MakeGenericMethod(firstType);
    
    	IQueryable<T> queryable = ((IQueryable)dbSet.Invoke(this, null)).Cast<T>();
    
    	return queryable.ToList().Cast<T>();
    }
