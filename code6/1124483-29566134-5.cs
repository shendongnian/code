    public abstract class Repository<T> : IDisposable where T : DbContext
    {
        private bool _disposed;
        private T _context;
        public Repository(T context)
        {
            _context = context;
        }
        protected T Context { get { return _context; } }
        public void SetSomething()
        {
            //...Access the database and set something for tracing
            // _context.Database.SqlQuery(....);
        }
        public void UnSetSomething()
        {
            //...Access the database and cancel something for tracing
            //_context.Database.SqlQuery(....);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
                OnDispose(disposing);
            }
            _disposed = true;
        }
        // this for the implementor to dispose their items but not the context because it's already disposed from the base class
        protected abstract void OnDispose(bool disposing); 
        ~Repository()
        {
            Dispose(false);
        }
    }
