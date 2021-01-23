    internal class UserConfiguration : DbEntityConfiguration<UserDto>
    {
        public override void Configure(EntityTypeBuilder<UserDto> entity)
        {
            entity.ForSqlServerToTable("User");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Username).HasMaxLength(255).IsRequired();
            // etc.
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
 
        modelBuilder.AddConfiguration(new UserConfiguration());
    }
