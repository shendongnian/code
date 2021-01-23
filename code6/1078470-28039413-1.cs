    [HttpGet]
    public ActionResult Edit(CreateVM model)
    {
      CreateVM model = new CreateVM();
      ...
      model.CityList = new SelectList(city, "cityname", "cityname");
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(CreateVM model)
    {
      // the model now contains the selected old name and its new name
    }
