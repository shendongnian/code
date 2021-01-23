        public class Repository<TEntity>
    	where TEntity : class, new()
    {
    	protected DbContext Context { get; set; }
    
    	public Repository(DbContext context)
    	{
    		Context = context;
    	}
    
    	public void Add(TEntity entity)
    	{
    		Context.Set<TEntity>().Add(entity);
    
    		Context.SaveChanges();
    	}
    
    	public void Add(IEnumerable<TEntity> entities)
    	{
    		Context.Set<TEntity>().AddRange(entities);
    
    		Context.SaveChanges();
    	}
    
    	public void Update(TEntity entity)
    	{
    		Context.Set<TEntity>().Attach(entity);
    		Context.Entry(entity).State = EntityState.Modified;
    
    		Context.SaveChanges();
    	}
    
    	public void Update(IEnumerable<TEntity> entities)
    	{
    		foreach (TEntity entity in entities)
    		{
    			Context.Set<TEntity>().Attach(entity);
    			Context.Entry(entity).State = EntityState.Modified;
    		}
    
    
    		Context.SaveChanges();
    	}
    
    	public void Remove(TEntity entity)
    	{
    		Context.Set<TEntity>().Attach(entity);
    		Context.Set<TEntity>().Remove(entity);
    
    		Context.SaveChanges();
    	}
    
    	public void Remove(IEnumerable<TEntity> entities)
    	{
    		Context.Set<TEntity>().RemoveRange(entities);
    
    		Context.SaveChanges();
    	}
    
    	public IQueryable<TEntity> AsQueryable()
    	{
    		return Context.Set<TEntity>();
    	}
    }
