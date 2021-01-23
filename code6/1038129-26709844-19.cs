    public class EFContext : DbContext, IGenericContext
    {
    	public EFContext(string connectionName)
    		: base(connectionName)
    	{
    
    	}
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
    		base.OnModelCreating(modelBuilder);
    	}
    
    	public void Add<T>(T entity) where T : class
    	{
    		this.Set<T>().Add(entity);
    
    		this.SaveChanges();
    	}
    
    	public void Update<T>(T entity) where T : class
    	{
    		this.Set<T>().Attach(entity);
    		this.Entry(entity).State = EntityState.Modified;
    
    		this.SaveChanges();
    	}
    
    	public void Delete<T>(T entity) where T : class
    	{
    		this.Set<T>().Attach(entity);
    		this.Set<T>().Remove(entity);
    
    		this.SaveChanges();
    	}
    
    	public IQueryable<T> GetIQueryable<T>() where T : class
    	{
    		return this.Set<T>();
    	}
    }
