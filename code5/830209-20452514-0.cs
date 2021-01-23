    public class MyDataContext : DbContext
    {
	    public override int SaveChanges()
	    {
		    foreach (var entry in this.ChangeTracker.Entries<MyClass>().Where(x => x.State == EntityState.Added))
		    {
			    entry.Entity.CreateTime = DateTimeOffset.Now;
		    }
		    return base.SaveChanges();
	    }
    }
