        public interface IUnitOfWork<T> where T : class, IEntity
        {
            IRepository<T> Repistory { get; }
            IRepository<TEntity> GetTypeRepository<TEntity>() where TEntity : class, IEntity;
            object GetContext();
            int Commit();
            Task<int> CommitAsync();
    }
  
