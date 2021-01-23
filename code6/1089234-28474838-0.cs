    public ActionResult Create()
    {
      RegisterViewModel model = new RegisterViewModel();
      model.CompanyId = 2; // set this if you want to display a specific company
      ConfigureViewModel(model);
      return View(model);
    }
    public ActionResult Create(RegisterViewModel model)
    {
      if(!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Save and redirect
    }
    private void ConfigureViewModel(RegisterViewModel model)
    {
      model.CompanyOptions = new List<SelectListItem>()
      {
        new SelectListItem() { Text = "Company 1", Value = "1" },
        new SelectListItem() { Text = "Company 2", Value = "2" }
      };
    }
