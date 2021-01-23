    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
            // No way to call DbContext.SaveChangesAsync() from here
        }
    }
