    public class UnitOfWork<TContext>
    {
        public UnitOfWork(string connectionString)
        {
            _ctx = (TContext)Activator.CreateInstance(typeof(TContext), new[] { connectionString });
        }
    }
