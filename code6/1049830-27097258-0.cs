    public interface IRepository<K, E>
        where K : IComparable, IComparable<K>
        where E : BaseUniqueEntity<K>
    {
    }
    
    public interface IRepository<E> : IRepository<int, E>
        where E : BaseUniqueEntity<int>
    {
    }
