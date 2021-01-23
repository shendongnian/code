    public interface IUnitOfWork : IDisposable
    {
        public IContext Context { get; }
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionString)
        {
            this.Context = new OrderContext(connectionString);
        }
        public IContext Context { get; private set; }
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
