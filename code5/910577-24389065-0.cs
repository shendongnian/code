	// make it generic
	public class BaseContextInitializer<T> : IDatabaseInitializer<T>
	{
	   // ...
	   public void InitializeDatabase(T context) 
	   {
	        // ...
	   }
	}
        // now pass the derivedcontext in the derived initializer
	public class DerivedContextInitializer : BaseContextInitializer<DerivedContext>
	{
		// overrides etc. etc.	
	} 
        // set the initializer to be the derived one
	public class DerivedContext : BaseContext {
	    public DbSet<Admin> Admins { get; set; }
	    public DerivedContext(): base("default")
	    {
	        Database.SetInitializer(new DerivedContextInitializer());
	    }
	    
	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
	        base.OnModelCreating(modelBuilder);
	        modelBuilder.Configurations.Add(new AdminConfiguration());
	    }
	}
