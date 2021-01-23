    public ActionResult Create()
    {
      UserCreateVM model = new UserCreateVM();
      ConfigureViewModel(model);
      return View(model);
    }
    public ActionResult Create(UserCreateVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // initialize new instances of the data model(s)
      // map properties from view model to data model
      // save and redirect
    }
    private void ConfigureViewModel(UserCreateVM model)
    {
      model.DeviceList = new SelectList(db.Devices, "DeviceID", "Name");
    }
