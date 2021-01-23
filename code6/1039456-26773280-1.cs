    public ActionResult Create()
    {
      var model = new UserRegistrationViewModel();
      var roles = from n in XDocument.Load(....
      model.RoleList = new SelectList(roles, "value", "value");
      ....
      return View(model);
    }
