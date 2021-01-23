    [AllowAnonymous]
    public ActionResult Register()
    {
        var allroles = Roles.GetAllRoles(); 
        return View(allroles);
    }
