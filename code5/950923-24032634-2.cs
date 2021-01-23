    public class MyContext : DbContext
    {
       public MyContext() : base()
       {
       }
     
       public DbSet<Policy> Policies { get; set; }
    
       protected override void OnModelCreating(ModelBuilder builder)
       {
          var policyMap = modelBuilder.Entity<Policy>();
    
          // Set up discriminators
          policyMap.Map<InsurancePolicy>(p => o.Requires("Type").HasValue("I"))
                   .Map<CarPolicy>(p => o.Requires("Type").HasValue("C"));
    
          // Notice that `Type` is only used for the discriminators, not an actual
          // mapped property
          policyMap.HasKey(x=>x.Id);
          policyMap.Property(x=>x.PolicyNumber);
       }
    }
