    public class BaseDal: IDisposable {
       private MyDbContext _context;
       public BaseDal() { _context = new MyDbContext; }
       public void Commit() { _context.SaveChanges(); }
    }
