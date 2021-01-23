    public class UnitOfWork : IUnitOfWork
    {
        internal EntitiesContext _context = new EntitiesContext ();
        private ITenantRepository _tenantRepository;
        private IOtherRepository _otherRepository;
        
        public ITenantRepository TenantRepository
        {
            get
            {
                if (_tenantRepository== null)
                {
                    _tenantRepository= new TenantRepository(_context);
                }
                return _tenantRepository;
            }
        }
        public IOtherRepository OtherRepository
        {
            get
            {
                if (_otherRepository== null)
                {
                    _otherRepository= new OtherRepository(_context);
                }
                return _otherRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
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
