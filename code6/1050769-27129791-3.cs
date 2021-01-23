	public IQueryable<TEntity> GetData<TEntity>() where TEntity : class
	{
		return _context.Set<TEntity>();
	}
    
	public IQueryable<Customer> GetAllProducts()
	{
		return GetData();
	}
	public IQueryable<Customer> GetMostOrderedProducts(int minimumOrders)
	{
		return GetData().Where(p => p.OrderCount > minimumOrders)
			.OrderByDescending(p=>p.OrderCount));
	}
