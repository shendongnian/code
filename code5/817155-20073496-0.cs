    public class UnitOfWork : IUnitOfWork
    {
        private ModelEntities _context;
      
        public ModelEntities Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public UnitOfWork(ModelEntities context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            this.Dispose(true);
        }
        public void Dispose(bool dispose){
            _context.Dispose();
        }
    }
