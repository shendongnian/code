     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
    
         modelBuilder.Entity<User>().HasMany(b => b.Tenants).WithMany(c => c.Users);
         modelBuilder.Entity<User>().HasOptional(b => b.CurrentTenant);
     }
