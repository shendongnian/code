        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
           modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});
        }
    
