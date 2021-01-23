    public class lister<TEntity>
        where  TEntity  : IPEntity
    {
        private DbContext _context;
        private DbSet<TEntity> Set
        {
            get { return _context.Set<TEntity>(); }
        }
        public lister(DbContext context)
        {
            _context = context;
        }
    }
