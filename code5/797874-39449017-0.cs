    public class GenericRepository<T> where T : class
    {
      private MyDatabase _Context;
      private DbSet<T> dbset;
    
      public GenericRepository(MyDatabase context)
      {
        _Context = context;
        dbSet = context.Set<T>();
      }
    
      public T Get(int id)
      {
        return dbSet.Find(id);
      }
      public IEnumerable<T> GetAll()
      {
        return dbSet<T>.ToList();
      }
      public IEnumerable<T> Where(Expression<Func<T>, bool>> predicate)
      {
        return dbSet.Where(predicate);
      }
      ...
      ...
    }
