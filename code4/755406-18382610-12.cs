    private IEnumerable<SelectListItem> GetRoles()
    {
        var dbUserRoles = new DbUserRoles();
        var roles = dbUserRoles
                    .GetRoles()
                    .Select(x =>
                            new SelectListItem
                                {
                                    Value = x.UserRoleId.ToString(),
                                    Text = x.UserRole
                                });
        
        return new SelectList(roles, "Value", "Text");
    }
    public ActionResult AddNewUser()
    {
        var model = new UserRoleViewModel
                        {
                            UserRoles = GetRoles()
                        };
        return View(model);
    }
