    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        internal ApplicationContext Context;
        internal DbSet<TEntity> Entities;
        public Repository(ApplicationContext context)
        {
            if (Context == null)
            {
                throw new ArgumentNullException();
            }
            
            Context = context;
            Entities = Context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;
            if(filter != null)
            {
                query = query.Where(filter);
            }
            query = includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            Entities.Add(entity);
        }
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Entities.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Entities.Attach(entityToDelete);
            }
            Entities.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            Entities.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
