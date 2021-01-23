    public class CachingRepositoryDecorator<TEntity> : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> decoratee;
        private readonly CachedRepositoryConfiguration configuration;
        public CachingRepositoryDecorator(IRepository<TEntity> decoratee,
            CachedRepositoryConfiguration configuration) {
            this.decoratee = decoratee;
            this.configuration = configuration;
        }
 
        // IRepository<T> methods here.
    }
    container.RegisterDecorator(typeof(IRepository<>), 
        typeof(CachingRepositoryDecorator<>));
    container.RegisterWithContext<CachedRepositoryConfiguration>(context => {
        if (context.ImplementationType == typeof(CachingRepositoryDecorator<Setting>)) {
            return CachedRepositoryConfiguration.AbsExpiration(TimeSpan.FromMinutes(30));
        } else {
            CachedRepositoryConfiguration.NoCaching;
        }
    });
