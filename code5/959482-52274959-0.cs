    public class ReferenceThing
    {
    	[Key]
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    public class MyDbContext : DbContext 
    {
    	public DbSet<ReferenceThing> ReferenceThing { get; set; }	
    }
