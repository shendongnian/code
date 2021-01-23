    using Data.EntityConfigurations;
    using Domain.Models;
    using System.Data.Entity;
    namespace Data.Contexts
    {
	    public class ApplicationContext : DbContext
	    {
		    /// <summary>
		    /// Constructor
		    /// </summary>
		    public ApplicationContext()
			    : base("ConnectionStringName")
		    { }
		    public DbSet<RegionalSalesManager> RegionalSalesManagers { get; set; }
		    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    		{
    			modelBuilder.Configurations.Add(new RegionalSalesManagerConfiguration());
    			base.OnModelCreating(modelBuilder);
    		}
    	}
    }
