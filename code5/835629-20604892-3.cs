    public class SampleContext: DbContext
    {    
        public SampleContext()
           : base("AnotherConnectionStringName")
        {
        }
    
        public DbSet<EFcodefirst.Models.Customer> Customers { get; set; }        
    }
