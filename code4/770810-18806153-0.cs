    public class DataService
    {
       public IList<T> All<T>() { ... }
       public T Get<T>(int id) { ... }
       ...
    }
    public class DataServiceProxy<T>
    {
        public DataServiceProxy(DataService ds)
        {
          this.ds = ds;
        }
        public IList<T> All() 
        { 
          return this.ds.All<T>();
        }
        public T Get(int id)
        {
          return this.ds.Get<T>(id);
        }
    }
