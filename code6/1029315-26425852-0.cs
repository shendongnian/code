    public class STOREitemsDBContext : DbContext
    {
        public STOREitemsDBContext():base("Connectionstring")           
        {
    
        }
        public DbSet<Price> PRICES { get; set; }
    }    
