    public interface IRepository
    {
        void Save(); 
    }
    public interface IRepository<T> : IRepository
    {
        // Other methods with T
    }
