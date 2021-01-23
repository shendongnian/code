      protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                .ToTable("AspNetUsers");
            modelBuilder.Entity<User>()
                .ToTable("AspNetUsers");
		}
