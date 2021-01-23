    var user = modelBuilder.Entity<TUser>()
        .ToTable("AspNetUsers");
    user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
    user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
    user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
    user.Property(u => u.UserName).IsRequired();
    modelBuilder.Entity<TUserRole>()
        .HasKey(r => new { r.UserId, r.RoleId })
        .ToTable("AspNetUserRoles");
    modelBuilder.Entity<TUserLogin>()
        .HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey})
        .ToTable("AspNetUserLogins");
    modelBuilder.Entity<TUserClaim>()
        .ToTable("AspNetUserClaims");
    var role = modelBuilder.Entity<TRole>()
        .ToTable("AspNetRoles");
    role.Property(r => r.Name).IsRequired();
    role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
