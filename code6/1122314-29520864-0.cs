    var roles = new List<Role>()
    {
    new Role("Admin", 1),
    new Role("SuperUser", 2),
    new Role("User", 1)
    };
    ctx.Roles.AddRange(roles);
    ctx.Users.Add(new User {Name = "Vovan Super", Age = 31, Roles = roles }  );
    ctx.SaveChanges();
