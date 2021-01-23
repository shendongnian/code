    public class CachingRepositoryDecorator<TEntity> : IRepository<TEntity>
    {
        private readonly IRepository<TEntity> decoratee;
        private readonly CachedRepositoryConfiguration<TEntity> configuration;
        public CachingRepositoryDecorator(IRepository<TEntity> decoratee,
            CachedRepositoryConfiguration<TEntity> configuration) {
            this.decoratee = decoratee;
            this.configuration = configuration;
        }
 
        // IRepository<T> methods here.
    }
    container.RegisterDecorator(typeof(IRepository<>), 
        typeof(CachingRepositoryDecorator<>));
    container.RegisterSingleton<CachedRepositoryConfiguration<Setting>>(
        CachedRepositoryConfiguration<Setting>.Absolute(TimeSpan.FromMinutes(30)));
    container.RegisterSingleton<CachedRepositoryConfiguration<Customer>>(
        CachedRepositoryConfiguration<Customer>.Sliding(TimeSpan.FromMinutes(5)));
    // Register the 'no caching' configuration as fallback
    container.Register(
        typeof(CachedRepositoryConfiguration<>),
        typeof(NoCachingCachedRepositoryConfiguration<>).
        Lifestyle.Singleton);
    public sealed class NoCachingCachedRepositoryConfiguration<T>
        : CachedRepositoryConfiguration<T>
    {
        public NoCachingCachedRepositoryConfiguration() : base(cache: false) { }
    }
