     modelBuilder.Entity<User>()
            .HasIndex(b => b.Email)
            .IsUnique();
     modelBuilder.Entity<User>()
            .HasIndex(b => b.UserName)
            .IsUnique();
