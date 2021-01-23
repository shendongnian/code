    public class Repository<TEntity>
    	where TEntity : class, new()
    {
    	protected IGenericContext Context { get; set; }
    
    	public Repository(IGenericContext context)
    	{
    		Context = context;
    	}
    
    	public void Add(TEntity entity)
    	{
    		Context.Add(entity);
    	}
    
    	public void Update(TEntity entity)
    	{
    		Context.Update(entity);
    	}
    
    	public void Delete(TEntity entity)
    	{
    		Context.Delete(entity);
    	}
    
    	public IQueryable<TEntity> AsQueryable()
    	{
    		return Context.GetIQueryable<TEntity>();
    	}
    }
