    using (var context = new ApplicationDbContext())
    {
        var users = context.Users.Include(u => u.Claims)
                                 .Include(u => u.Logins)
                                 .Include(u => u.Roles)
                                 .ToList();
        var roles = context.Roles.ToList();
    }
