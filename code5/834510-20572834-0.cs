    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(@"Your connection string here") { }
    
     // Rest of your DbContext code
    
    }
