    public class UserMapping : IEntityMappingConfiguration<User>
    {
        public void Map(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("UserId");
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(64);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(64);
            builder.Property(m => m.DateOfBirth);
            builder.Property(m => m.MobileNumber).IsRequired(false);
        }
    }
