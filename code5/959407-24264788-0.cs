    public ActionResult Index(LoginModel model) {
      if (ModelState.IsValid) {
        if (AuthenticateUser(model)) {
          return RedirectToAction("LoggedIn");
        } else {
          ModelState.AddModelError("", "Could not authenticate"); //or better error
        }
      }
    
      return View(model);
    }
