    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("MyConnectionStringName") { }
    
     // Rest of your DbContext code
    
    }
