    public IQueryable<TEntity> GetData<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>();
    }
    
    pubic IQueryable<Customer> GetAllProducts()
    {
        return GetData();
    }
    
    pubic IQueryable<Customer> GetMostOrderedProducts(int minimumOrders)
    {
        return GetData().Where(p => p.OrderCount > minimumOrders).OrderByDescending(p=>p.OrderCount));
    }
