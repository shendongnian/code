    public class Vehicle
    {
    	public int ID { get; set; }
    	public string Name { get; set; }
    	public virtual Job Job { get; set; }
    }
    
    public class Job
    {
    	public int ID { get; set; }
    	public string Description { get; set; }
    }
    
    public class AppDataContext : DbContext
    {
    	public DbSet<Vehicle> Vehicles { get; set; }
    	public DbSet<Job> Jobs { get; set; }
    
    	protected override void OnModelCreating(DbModelBuilder mb)
    	{
    		mb.Entity<Job>().HasKey(x => x.ID);
    		mb.Entity<Vehicle>().HasKey(x => x.ID);
    		mb.Entity<Vehicle>().HasOptional(x => x.Job).WithOptionalDependent();
    
    		// ... other config, constraints, etc
    	}
    }
