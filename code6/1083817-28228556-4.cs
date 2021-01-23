    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private connectionInformation;
        public GenericRepository<T>(object connectionInformation)
        {
            // do something with the connection info, dbContext, etc...
        }
    	public T Add(T entity)
        {
        	// implementation...
        }
    	public T Update(T entity)
    	{
        	// implementation...
        }
    	
    	public T Delete(T entity)
    	{
        	// implementation...
        }
    	
    	public List<T> GetAll()
    	{
        	// implementation...
        }
    }
