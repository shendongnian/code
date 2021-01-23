    public class MyContext : DbContext
    {
    	public virtual IDbSet<Company> Companies { get; set; }
     
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Entity<Company>()
    			.Map(m => m.Requires("IsDeleted").HasValue(false))
    			.Ignore(m => m.IsDeleted);
    	}
    }
