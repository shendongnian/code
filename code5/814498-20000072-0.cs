    public interface IRepository<T>
    {
      IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> predicate);
    }
    
    // A base class that can carry helper functionality.
    public abstract class Repository<T> : IRepository<T>
    {
      private readonly IEnumerable<T> _entities;
    
      protected Repository(IEnumerable<T> entities)
      {
        _entities = entities;
      }
    
      public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
      {
        return _entities.Where(predicate);
      }
    }
    
    // Concrete implementation
    public class MyEntityRepository : Repository<MyEntity>
    {
      public MyEntityRepository() : base(new MyDbContext().MyEntities) { }
    }
