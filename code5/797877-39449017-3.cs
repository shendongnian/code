    public interface IUnitOfWork
    {
      ITable1 table1 {get;}
      ...
      ...
      list all other repository interfaces here.
    
      void SaveChanges();
    } 
    public class UnitOfWork : IUnitOfWork
    {
      private readonly MyDatabase _context;
      public ITable1 Table1 {get; private set;}
      public UnitOfWork(MyDatabase context)
      {
        _context = context; 
        // Initialize all of your repositories here
        Table1 = new Table1Repository(_context);
        ...
        ...
      }
    
      public void SaveChanges()
      {
        _context.SaveChanges();
      }
    }
