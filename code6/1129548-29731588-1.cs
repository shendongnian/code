    public ActionResult Roles()
    {
        var vm = new AddUserRoleVM();
        vm.Roles = GetRoles();
        return View(vm);
    }
    private List<UserRoleVM> GetRoles()
    {
        //Hard coded for demo.You should get the roles from db
        return new List<UserRoleVM>
        {
            new UserRoleVM {RoleId = 1, RoleName = "Admin"},
            new UserRoleVM {RoleId = 2, RoleName = "Editor"}
        };
    }
