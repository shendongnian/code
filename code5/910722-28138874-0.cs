    if (model.Roles == null)
    {
         model.Roles = new Role();
    }
      else {
    foreach (var role in model.Roles)
            {
                if (role.Selected)
                {
                    idManager.AddUserToRole(user.Id, role.RoleName);
                }
            }
     }
