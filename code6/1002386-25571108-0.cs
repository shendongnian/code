    public interface IReadOnlyRepositoryBase<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        IEnumerable<TEntity> GetAll();
    }
