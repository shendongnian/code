    public class YourContext : DbContext
    {
    	public DbSet<Task> Tasks { get; set; }
    	
    	// Other stuff
    	
    	protected override void OnModelCreating(DbModelBuilder modelBuilder)
    	{
    		base.OnModelCreating(modelBuilder);
    		
    		modelBuilder.Entity<Task>()
    			.HasMany(t => t.SubTasks)
    			.WithOptional(t => t.ParentTask);
    	}
    }
