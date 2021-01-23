        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
		   base.OnModelCreating(modelBuilder);
		  // modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);                // do not add this
          // modelBuilder.Entity<IdentityUserRole>().HasKey(r => new {r.RoleId, r.UserId});         // do not add this
		  // other mapping codes
        }
