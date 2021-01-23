	public interface IUnitOfWork
	{  
	    //the newly added.
	    T GetInheretedRepository<T, TEntity>() where T : class, IRepository<TEntity>; 
	}
	public interface IRepository<TEntity>
	{
	    TEntity Resolve(); // dummy function, just to get the idea
	}
