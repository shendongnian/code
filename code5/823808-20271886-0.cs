    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection") //<--- change it to your connectionstringname
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
