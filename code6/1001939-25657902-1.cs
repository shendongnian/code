    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUserLogin>().HasKey<int>(l => l.UserId);
        modelBuilder.Entity<ApplicationRole>().HasKey<int>(r => r.Id);
        modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { r.RoleId, r.UserId });
    }
