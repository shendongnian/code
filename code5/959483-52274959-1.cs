    public class MyDbContextWhichAllowsIdentityInsert : MyDbContext
    {
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		
    		modelBuilder.Entity<ReferenceThing>()
    					.Property(x => x.Id)
    					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
    	}
    }
