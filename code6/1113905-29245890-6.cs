    public ActionResult Create()
    {
      UserCreateVM model = new UserCreateVM();
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(UserCreateVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Initialize new instance of the data model
      User user = new User();
      // Map properties from view model to data model
      user.CodeName = model.CodeName;
      user.UseBriefInstructions = model.UseBriefInstructions;
      user.Device = db.Devices.Find(model.SelectedDevice);
      // Save and redirect
      db.Users.Add(user);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
    private void ConfigureViewModel(UserCreateVM model)
    {
      model.DeviceList = new SelectList(db.Devices, "DeviceID", "Name");
    }
