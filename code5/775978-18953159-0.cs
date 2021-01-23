    public class EFRepository<T> where T : class
    {
        private DbContext _context;        
        
        public EFRepository(DbContext context)
        {
            this._context = context;
        }
        public void Insert(T entity)
        {
            this._context.Entry<T>(entity).State = EntityState.Added;
        }
        public bool Commit()
        {
            return this._context.SaveChanges() > 0;
        }
    }
