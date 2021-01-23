    public class UserProfileConfiguration : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            HasKey(k => k.UserId);
            HasMany<UserRole>(r => r.Roles)
                .WithMany(u => u.UserProfiles)
                .Map(m =>
                {
                    m.ToTable("aspnet_UsersInRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
        }
    }
