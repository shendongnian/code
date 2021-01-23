    public class Table1Repository : GenericRepository<table1>, ITable1
    {
      private MyDatabase _context;
      public Table1Repository(MyDatabase context) : base(context)
      {
        _context = context;
      }
    } 
