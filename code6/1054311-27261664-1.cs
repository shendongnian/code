    public ActionResult Create()
    {
      ApplicationVM model = new ApplicationVM();
      model.LoanOfficerList = new SelectList(db.Users, "Id", "FullName");
      return View();
    }
    [HttpPost]
    public ActionResult Create(ApplicationVM model)
    {
      if(!ModelState.IsValid)
      {
        model.LoanOfficerList = new SelectList(db.Users, "Id", "FullName");
        return View(model);
      }
      // Initialize new Application, set properties from the view model, save and redirect
    }
