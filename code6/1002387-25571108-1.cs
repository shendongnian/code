    public interface IReadOnlyRepositoryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        IQueryable<TEntity> GetAll();
    }
