    var users = UserManager.Users.ToList();
    var superAdmins = RoleManager.Roles.Single(b => b.Name == "Super Admin").Users;
    foreach (var superAdmin in superAdmins)
    {
        users.RemoveAll(c => c.Id == superAdmin.UserId);
    }
    return View(users.ToList());
