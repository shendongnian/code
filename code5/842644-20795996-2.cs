    public class GenericRepository<TEntity> where TEntity : class
    {
        public virtual TEntity GetByID(object id)
        {
            // ...
        }
        public virtual void Insert(TEntity entity)
        {
            // ...
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            // ...
        }
    }
