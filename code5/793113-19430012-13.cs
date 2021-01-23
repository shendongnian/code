    public EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
    	private readonly DatingSiteContext _context;
    	
    	public EfRepository()
    	{
    		_context = new DatingSiteContext();
    	}
    	
    	private IDbSet<TEntity> Entities
    	{
    		get
    		{
    			return _context.Set<TEntity>();
    		}
    	}
    
    	public IEnumerable<TEntity> GetAll()
    	{
    		return Entities.ToList();
    	}
    	
    	public TEntity GetById(int id)
    	{
    		return Entities.Find(id);
    	}
    	
    	public IQueryable<TEntity> Table 
    	{ 
    		get { return Entities; }
    	}	
    }
