    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<User>()
                   .HasMany<Role>(u => u.Roles)
                   .WithMany(c => c.Users)
                   .Map(cs =>
                            {
                                cs.MapLeftKey("UserId");
                                cs.MapRightKey("RoleId");
                                cs.ToTable("UserRoles");
                            });
    }
