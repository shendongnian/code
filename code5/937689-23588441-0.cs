    public class RepositoryContainer
    {
        public IGenericRepository<T> Get<T>() where T : class
        {
	     return new GenericRepository<T>();
        }
    }
