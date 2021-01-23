        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Content>()
                .HasMany(c => c.Editors)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Content>()
                .HasRequired(c => c.Owner)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
