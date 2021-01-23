    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
    
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // other implementation
        public void Dispose()
        {
            context.SaveChanges();
        }
    }
