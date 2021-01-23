    public class lister<TEntity, TContext> 
        where  TEntity  : IPEntity
        where  TContext  : DbContext, new()
    {
        private TContext _context;
        private DbSet<TEntity> Set
        {
            get { return _context.Set<TEntity>(); }
        }
        public lister()
        {
            _context = new TContext();
        }
    }
