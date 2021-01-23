    public interface IRepository<TEntity> : IDisposable where TEntity : class 
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Find(params object[] keys);
        void Add(TEntity entity, bool save = true);
        void Edit(TEntity entity, bool save = true);
        void Delete(bool save = true, params object[] keys);
        void Save();
    }
