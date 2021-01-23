public class DbContextWrapper : IContext, IDisposable
{
  private MyDbContext _context;
  public DbContextWrapper()
  {
    this._context = new MyDbContext();
  }
  IDbSet&lt;Product> IContext.Products
  {
    get { return this._context.Products; }
  }
  public void Dispose()
  {
    this._context.Dispose();
  }
}
