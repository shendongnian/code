    protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        var applicationUser = modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id).ToTable("Users", "dbo");
        applicationUser.Property(iu => iu.UserId).HasColumnName("UserId");
        ...
