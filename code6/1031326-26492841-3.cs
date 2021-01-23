    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public virtual IDbSet<ApplicationUser> Users { get; set; }
    }
