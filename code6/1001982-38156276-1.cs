    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().Ignore(c => c.AccessFailedCount)
                                               .Ignore(c=> c.LockoutEnabled)
                                               .Ignore(c=>c.LockoutEndDateUtc)
                                               .Ignore(c=>c.Roles)
                                               .Ignore(c=>c.TwoFactorEnabled);//and so on...
            modelBuilder.Entity<IdentityUser>().ToTable("Users");//to change the name of table.
            
    }
