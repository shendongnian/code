    public IQueryable<T> GetQueryableObjects<T>()
    {
    	
    	return _db.GetObjectSet<T>();
    }
