    public class GenericRepository<TEntity>:IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        ...
    }
