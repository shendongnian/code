    [Authorize(Roles = "Admin")]
    public ActionResult Register(string name, string email)
    {
        RegisterViewModel model = new RegisterViewModel()
        {
             Name = name, 
             Email = email
        };
        return View(model);
    }
