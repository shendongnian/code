    public class TableWithIntId : ModelBase<int>
    {
    }
    public class TableWithGuidId : ModelBase<Guid>
    {
    }
    public class Repository<TEntity, T> : IRepository<TEntity> 
        where TEntity : ModelBase<T>
    {
    }
    public class TableWithIntIdRepository<TTable> : Repository<TTable, int>
        where TTable : TableWithIntId
    {
    }
    public class TableWithGuidIdRepository<TTable> : Repository<TTable, Guid>
        where TTable : TableWithGuidId
    {
    }
