    public class RepositoryManager
    {
        public Type Context { get; private set; }
        public RepositoryManager(Type context)
        {
            Context = context;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            var contextInstance = Activator.CreateInstance(Context);
            var repositoryType = typeof(Repository<>).MakeGenericType(Context);
            var repository = Activator.CreateInstance(repositoryType, contextInstance);
            return (IRepository<T>)repository;
        }
    }
