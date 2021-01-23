    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal MyDbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(MyDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }
        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
        public virtual TEntity GetById(long id)
        {
            return dbSet.Find(id);
        }
		//And so on...
		
