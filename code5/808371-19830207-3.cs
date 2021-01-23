    [AllowAnonymous]
    public ActionResult Register()
    {
        var allroles = Roles.GetAllRoles(); 
        var model =  // createUserModel
        return View(model);
    }
