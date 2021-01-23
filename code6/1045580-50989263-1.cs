        public class UserUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserUserRole>
        {
            public void Configure(EntityTypeBuilder<UserUserRole> builder)
            {
                builder.ToTable("UserUserRole");
                // compound PK
                builder.HasKey(p => new { p.UserId, p.UserRoleId });
            }
        }
