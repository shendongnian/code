    var Db = new ApplicationDbContext();
    var idManager = new IdentityManager(Db);
    var user = Db.Users.First(u => u.UserName == model.UserName);
    idManager.ClearUserRoles(user.Id);
    foreach (var role in model.Roles)
    {
        if (role.Selected)
        {
            idManager.AddUserToRole(user.Id, role.RoleName);
        }
    }
