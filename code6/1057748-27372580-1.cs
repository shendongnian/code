    public interface IEntity<T> where T:class
    {
       void Save(T entity); // Must have return type
       void Update(T entity); // Drop the public
       IEnumerable<T> GetAll();
       T GetById(int id);
    }
