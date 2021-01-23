    public ActionResult AddRole(int ID)
    {
      UserRoleVM model = new UserRoleVM();
      var user = // Get the user based on the ID
      model.ID = ID;
      model.Name = user.??
      var roles = // Get all roles and remove those that the user already has
      model.RoleList = new SelectList(roles, "ID", "RoleName");
      return View(model);
    }
