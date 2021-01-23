    public interface IEntityRepository<TEntity, TId>
        : IDisposable
        where TEntity : class, IEntity<TId>
        where TId : IComparable
    {
        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> where = null,
            Expression<Func<TEntity, object>> orderBy = null);
        PaginatedList<TEntity> Paginate(int pageIndex, int pageSize);
        TEntity GetSingle(TId id);
        
        IQueryable<TEntity> GetAllIncluding(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, object>> orderBy,
            params Expression<Func<TEntity, object>>[] includeProperties);
        
        TEntity GetSingleIncluding(
            TId id, params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        void Attach(TEntity entity);
        void Edit(TEntity entity);
        void Delete(TEntity entity);
        int Save();
    }
