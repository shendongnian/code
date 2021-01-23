    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        
        public ICollection<User> FriendShips { get; set; }
        public User()
        {
            FriendShips = new HashSet<User>();
        }
    }
    
    
    public class SocialContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<User>()
            .HasMany(p => p.FriendShips)
            .WithMany()
            .Map(mc =>
            {
                
                mc.ToTable("userfriends");
            });
        }
    }
