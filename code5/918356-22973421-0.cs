    public class DataContext :  IdentityDbContext<ApplicationUser> 
    {
        public DataContext()
            : base("DefaultConnection")
        {
            
        }
        public IDbSet<Project> Projects { set; get; }
        public IDbSet<Task> Tasks { set; get; }
    }
