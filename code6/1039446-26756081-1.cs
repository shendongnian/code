    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                    .HasMany(x => x.roles)
                    .WithMany(x => x.users)
                    .Map(x =>
                    {
                        x.MapLeftKey("userId");
                        x.MapRightKey("roleId");
                        x.ToTable("UserRole");
                    });
    }
