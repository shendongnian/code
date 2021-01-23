    public class DepartmentDb : DbContext
    {
    public DepartmentDb() : base("DefaultConnection")
    {
 
    }
 
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Entry> Entries { get; set; }
 
    }
 
    // your repository
    public class DepartmentRepository: IDisposable
    {
    protected bool isDisposed = false;
    private DepartmentDb Context { get; set; } 
 
    // read (public)
    public IQueryable<user> Users { get { return Context.Users; } }
    public IQueryable<department> Departments { get { return Context.Departments; } }
    public IQueryable<entry> Entries { get { return Context.Entries; } }
 
    public DepartmentRepository() 
    {
         Context = new DepartmentDb();
    }
 
    public int Insert(User item)
    { 
        Context.Users.Add(item);
        return Context.SaveChanges();
    }
 
    public int Update(User item)
    { 
        Context.Entry<user>(item).State = EntityState.Modified;
        return Context.SaveChanges();
    }
 
    public int Delete(User item)
    { 
        Context.Users.Remove(item);
        return Context.SaveChanges();
    }
 
    protected virtual void Dispose(bool disposing)
    {
	if (isDisposed)
		return;
 
	if (disposing)
	{
		if (this.Context != null)
		{
			this.Context.Dispose();
			this.Context = null;
		}
	}
 
	isDisposed = true;
    }
 
    public void Dispose()
    {
	Dispose(true);
	GC.SuppressFinalize(this);
    }	
 
    }
