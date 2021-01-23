        public class UserContext : DbContext 
        {
            DbSet<User> users { get; set; }        
        }
    
