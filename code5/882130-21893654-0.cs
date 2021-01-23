    modelBuilder.Entity<User>()
        .HasMany(u => u.RoleDepartments)
        .WithRequired(urd => urd.User)
        .WillCascadeOnDelete();
    modelBuilder.Entity<Role>()
        .HasMany(r => r.UserDepartments)
        .WithRequired(urd => urd.Role)
        .WillCascadeOnDelete();
    modelBuilder.Entity<Department>()
        .HasMany(d => d.UserRoles)
        .WithRequired(urd => urd.Department)
        .WillCascadeOnDelete();
