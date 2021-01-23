    public class RepositoryProxy<TEntity> : IRepository<TEntity>
    {
        private readonly Func<IRepository<TEntity>> repositoryFactory;
        public CustomerRepositoryProxy(Func<IRepository<TEntity>> repositoryFactory) {
            this.repositoryFactory = repositoryFactory;
        }
        public void Add(TEntity entity) {
            var repository = this.repositoryFactory.Invoke();
            repository.Add(entity);
        }
    }
