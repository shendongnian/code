    public interface IRepository<T>
    {
        ...
        T Get(int id);
        void Save();
    }
