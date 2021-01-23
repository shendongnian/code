    public interface IRepository<TEntity>
    {
       IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedEnumerable<TEntity>> orderBy = null,
            string includeProperties = "")
    }
