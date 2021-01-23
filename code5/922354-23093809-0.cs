    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        ...
    }
    public class Repository<T> : IRepository<T>
    {   
        // dbset or list or whatever you're persisting to
        public void Add(T entity) {
           // add to dbSet
        }     
        public void Remove(T entity) {
           // remove from dbSet
        }
    }
