    protected override void Seed(DbModelContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context", "Context must not be null.");
        }
        const string UserName = "User";
        const string RoleName = "UserRole";
        var userRole = new IdentityRole { Name = RoleName, Id = Guid.NewGuid().ToString() };
        context.Roles.Add(userRole);
        var hasher = new PasswordHasher();
        var user = new IdentityUser
                       {
                           UserName = UserName,
                           PasswordHash = hasher.HashPassword(UserName),
                           Email = "test@test.com",
                           EmailConfirmed = true,
                           SecurityStamp = Guid.NewGuid().ToString()
                       };
        user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
        context.Users.Add(user);
        base.Seed(context);
    }
