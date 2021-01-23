    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection"){}
        public DbSet<Organisation> Organisations { get; set; }
        ...
    }
