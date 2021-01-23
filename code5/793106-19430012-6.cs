    public interface IRepository<TEntity> 
    	where TEntity : class, new()
    {
    	IEnumerable<TEntity> GetAll();
    	
    	TEntity GetById(int id);
    	
    	IQueryable<TEntity> Table { get; }
    }
