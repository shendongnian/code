    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
    
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbEntities Context;
        protected readonly DbSet<TEntity> Set;
    
        public Repository()
        {
            Context = new DbEntities();
            Set = Context.Set<TEntity>();
        }
    
        public virtual IQueryable<TEntity> GetAll()
        {
            return Set;
        }
    
        public virtual IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }
    
        public virtual TEntity GetById(long id)
        {
            return Set.Find(id);
        }
    
        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
            Context.SaveChanges();
        }
    
        public virtual void Update(TEntity entity)
        {
            Set.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    
        public virtual void Delete(TEntity entity)
        {
            Set.Remove(entity);
            Context.SaveChanges();
        }
    }
    // And assuming User is a data object with an Id property:
    public interface IUserSpecificRepository
    {
        List<User> GetById(long id)
    }
    public class UserSpecificRepository : IUserSpecificRepository, Repository<User>
    {
        public virtual List<User> GetById(long id)
        {
            return GetBy(x => x.Id = id).ToList();
        }
    }
