    public class UnitOfWork : IUnitOfWork
    {
       private readonly VotingSystemContext _context;
       private bool _disposed;
       public UnitOfWork(DbContext context)
       {
           _context = context;
       }
       public IDbSet<T> Set<T>()
       {
           return _context.Set<T>();
       ]
    }
