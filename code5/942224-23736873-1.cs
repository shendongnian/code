    public class UserMap : EntityTypeConfiguration<User>
        {
            public UserMap()
            {
                // Primary Key
                this.HasKey(t => t.UserId);
    
                // Properties
                this.Property(t => t.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
    }
