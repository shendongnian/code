     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<Permission>().HasKey(p => p.Id);
            modelBuilder.Entity<Permission>().Property(u => u.Name).IsRequired();
            //configuring the many-to-many relationship
            modelBuilder.Entity<User>()
                .HasMany(u => u.Permissions)
                .WithMany(p => p.Users)
                .Map(c => c.ToTable("UserPermissions"));
     }
