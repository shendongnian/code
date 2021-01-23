    public class GenericRepository<TEntity>:IRepository<TEntity> 
        where TEntity : IEntity
    {
        ...
    }
