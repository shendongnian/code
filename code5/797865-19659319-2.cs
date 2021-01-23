    public interface IDbContext
    {
       void Add<T>(T entity);
    }
    
    public interface IUnitOfWork
    {
       void Commit();
    }
    
    public class UnitOfWork : IDbContext, IUnitOfWork
    {
       public void Add<T>(T entity);
       public void Commit();
    }
    public class RepositoryBase<T>
    {
        private IDbContext _c;
    
        public RepositoryBase(IDbContext c) 
        {
           _c = c;
        }
    
        public void Add(T entity)
        {
           _c.Add(entity)
        }
    }
