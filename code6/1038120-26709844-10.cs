    public class EFContext : DbContext
    {
    	public EFContext(string connectionName)
    		: base(connectionName)
    	{
    
    	}
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		modelBuilder.Configurations.AddFromAssembly(this.GetType().Assembly);
    		base.OnModelCreating(modelBuilder);
    	}
    }
