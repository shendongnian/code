    public interface IRepository<T>{}
    public class Repository<T>:IRepository<T>{}
    public class RepositoryCache<T> : IRepository<T>
    {
        private readonly IRepository<T> _internalRepo;
        public RepositoryCache(IRepository<T> internalRepo)
        {
            _internalRepo = internalRepo;
        }
        public IRepository<T> InternalRepo
        {
            get { return _internalRepo; }
        }
    }
