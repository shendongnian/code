    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<ApplicationUser>()
                   .HasMany<Group>(g => g.Groups)
                   .WithMany(u => u.ApplicationUsers)
                   .Map(ug =>
                            {
                                ug.MapLeftKey("UserId");
                                ug.MapRightKey("GroupId");
                                ug.ToTable("UserGroup");
                            });
    }
