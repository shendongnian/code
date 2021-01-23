    public IEnumerable<SelectListItem> GetRoles()
    {
        DbUserRoles Roles = new DbUserRoles();
        return Roles.GetRoles
                    .Select(x => new SelectListItem
                                     {
                                        Value = x.UserRoleId,
                                        Text = x.UserRole
                                     })
                    .ToList();
    }
    public ActionResult AddNewUser()
    {
        var model = new UserRoleViewModel
                        {
                            UserRoles = GetRoles()
                        };
        return View(model);
    }
