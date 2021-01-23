    public interface IGenericRepository<T> where T : class
    {
    	Add(T entity);
    	Update(T entity);
    	Delete(T entity);
    	GetAll();
    }
