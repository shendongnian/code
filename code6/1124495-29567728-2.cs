    [HttpPost]
    public ActionResult Register(UserViewModel model)
    {
        if ((ModelState.IsValid) &&
            (model.Password == model.ConfirmPassword))
        {
            // map to EF model
            var user = new UserModel
            {
                Name = model.Name,
                Password = e.encrypt(model.Password)  // transform, encrypt, whatever
            };
            db.Users.Add(user);  // use EF model to persist
            ...
            return RedirectToAction("Login", "Account");
        }
        return(model);
    }
