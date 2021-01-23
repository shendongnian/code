        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            // base.OnModelCreating( modelBuilder );
            Precision.ConfigureModelBuilder(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>( l => l.UserId );
            modelBuilder.Entity<IdentityRole>().HasKey<string>( r => r.Id );
            modelBuilder.Entity<IdentityUserRole>().HasKey( r => new { r.RoleId, r.UserId } );
        }
