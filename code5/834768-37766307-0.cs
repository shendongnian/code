    string id = User.Identity.GetUserId();
    var user = UserManager.FindById(id);
    if(!UserManager.CheckPassword(user, model.Password))
    {
        ModelState.AddModelError("Password", "Incorrect password.");
    }
