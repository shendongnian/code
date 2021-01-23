    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
        public UserProfile UserProfile { get; set; }
    }
    
    public class UserProfile
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    
        public virtual User User { get; set; }
    }
    
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            HasKey(p => p.UserId);
    
            HasRequired(p => p.User).WithRequiredDependent(u => u.UserProfile);
        }
    }
