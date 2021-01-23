    public interface IRepository
    {
        void Create(object obj);
        object Retrieve(string key);
    }
