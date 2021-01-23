    public class ApplicationDbContext : IdentityDbContext<student>
        {
            public ApplicationDbContext() : base()
            {
                
            }
    
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
 
