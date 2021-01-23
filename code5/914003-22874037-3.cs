    var users = UserManager.Users.ToList();
    var roles = RoleManager.Roles.Where(a => a.Name != "Super Admin").ToList();
    var superAdmins = RoleManager.Roles.Single(b => b.Name == "Super Admin").Users;
    var userList = new List<IdentityUserRole>();
    foreach (var role in roles)
    {
        userList.AddRange(role.Users.ToList());
    }
    foreach (var superAdmin in superAdmins)
    {
        userList.RemoveAll(x => x.UserId == superAdmin.UserId);
    }
    var list = (from r in userList
                join u in users on r.UserId equals u.Id
                orderby u.FirstName ascending
                orderby u.LastName ascending
                select u).Distinct();
    return View(list);
