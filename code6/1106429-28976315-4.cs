    public ActionResult Create()
    {
      UserViewModel model = new UserViewModel();
      ConfigureViewModel(model);
      return View(model);
    }
    public ActionResult Create(UserViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Save and redirect
    }
    private void ConfigureViewModel(UserViewModel model)
    {
      var provinces = serviceClient.GetProvinces();
      model.ProvinceList = new SelectList(provinces, "ProvinceId", "ProvinceName");
    }
