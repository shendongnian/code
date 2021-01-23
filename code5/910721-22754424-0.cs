    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public ActionResult UserRoles(SelectUserRolesViewModel model)
    {
        if (ModelState.IsValid)
        {
            var idManager = new IdentityManager();
            var Db = new ApplicationDbContext();
            var user = Db.Users.First(u => u.UserName == model.UserName);
            idManager.ClearUserRoles(user.Id);
            foreach (var role in model.Roles)
            {
                if (role.Selected)
                {
                    idManager.AddUserToRole(user.Id, role.RoleName);
                }
            }
            Db.SaveChanges(); //for saving changes to the database 
            return RedirectToAction("IndexUser");
        }
        return View();
    }
