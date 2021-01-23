        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("SystemUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("SystemRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("SystemUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("SystemUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("SystemUserClaims");
        }
