    public interface IRepository
    {
        void Save(); 
    }
    public interface IRepository<T>
    {
        // Other methods with T
    }
