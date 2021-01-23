    class UserProfileEntities : DbContext
    {
        static UserProfileEntities()
        {
            Database.SetInitializer<UserProfileEntities>( null );
        }
        public DbSet<UserProfile> UserProfiles { get; set; }        
    }
