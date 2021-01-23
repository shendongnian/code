    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IdentityDbContext<ApplicationUser> _dbContext;
        public IDbSet<ApplicationUser> Users { get { return _dbContext.Users; } }
        public ApplicationDbContext(IdentityDbContext<ApplicationUser> dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<Book> Books { get; set; }
    }
