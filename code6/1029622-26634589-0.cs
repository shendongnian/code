    public abstract class RepositoryBase<TEntity>: IRepositoryBase<TEntity>
    {
        public MyEntities EntitiesContext { get; set; }
        public IList<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
        {
           return EntitiesContext.Set<TEntity>().Where(filter).ToList()
        }
    }
