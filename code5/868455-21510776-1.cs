    public class EFRepository : IRepository
    {
       ...
       public IQueryable<T> Query<T>()
       {
           return DataContrxt.Set<T>();
       }
    }
