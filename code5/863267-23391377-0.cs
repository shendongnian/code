    public class UnitOfWork : IUnitOfWork
    {
        private MyContext _context;
        public UnitOfWork()
        {
            this._context = new MyContext();
        }
        
        public void Save()
        {
            this._context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public MyContext Context
        {
            get { return this._context; }
        }
    }
