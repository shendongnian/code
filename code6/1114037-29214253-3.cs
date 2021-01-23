    public class CachingRepositoryDecorator<TEntity> : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> decoratee;
        public CachingRepositoryDecorator(IRepository<TEntity> decoratee) {
            this.decoratee = decoratee;
            this.Configuration = CachedRepositoryConfiguration.NoCaching;
        }
        public CachedRepositoryConfiguration Configuration { get; set; }
 
        // IRepository<T> methods here.
    }
    container.RegisterDecorator(typeof(IRepository<>), 
        typeof(CachingRepositoryDecorator<>));
    container.RegisterInitializer<CachingRepositoryDecorator<Setting>>(decorator => {
       decorator.Configuration = 
           CachedRepositoryConfiguration.AbsoluteExpiration(TimeSpan.FromMinutes(30));
    });
