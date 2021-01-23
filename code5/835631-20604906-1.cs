    public class SampleContext: DbContext
    {    
        public SampleContext()
           : base("DefaultConnection")
        {
        }
    
        public DbSet<EFcodefirst.Models.Customer> Customers { get; set; }        
    }
