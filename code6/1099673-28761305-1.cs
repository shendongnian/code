    public interface IRepository<T> : IRepository
    {
        T Get(int id);
        ...
    }
