     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            internal IDbContext Context;
            internal IDbSet<TEntity> DbSet;
    
            public Repository(IDbContext context)
            {
                Context = context;
                DbSet = context.Set<TEntity>();
            }
    
            public virtual TEntity FindById(object id)
            {
                return DbSet.Find(id);
            }
    
            public virtual void Update(TEntity entity)
            {
                DbSet.Attach(entity);
            }
            public virtual void Delete(object id)
            {
                var entity = DbSet.Find(id);
                var objectState = entity as IObjectState;
                if (objectState != null)
                    objectState.State = ObjectState.Deleted;
                Delete(entity);
            }
    
            public virtual void Delete(TEntity entity)
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
    
            public virtual void Insert(TEntity entity)
            {
                DbSet.Attach(entity);
            }
    
            public virtual List<TEntity> GetAll()
            {
                return DbSet.ToList();
            }
        }
