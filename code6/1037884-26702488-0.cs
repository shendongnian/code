    public interface IRepository<T>
    {
       T Get(int id);
       IEnumerable<T> GetAll();
       T Update(T item)
       void Delete(int id);
    }
