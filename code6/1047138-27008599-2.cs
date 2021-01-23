    public ActionResult Register()
    {
      var model = new LoginAndRegisterViewModel();
      return View("Login", model);
    }
