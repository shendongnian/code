    public interface IRepository<T>
        where T : IDbItentity
    {
        IList<T> GetAll();
        T GetById(int id);
        int Insert(T saveThis);
        void Update(T updateThis);
        void Delete(T deleteThis);
    }
