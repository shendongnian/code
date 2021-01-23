    public ActionResult UnregisteredSection(string dropdownlistReturnValue) // dont know what dropdownlistReturnValue is doing?
    {
      CustomCar model = new CustomCar();
      model.CustomCarsList = // some value
      ViewBag.CustomCars = new SelectList(db.Garage.SqlQuery(selectString), "CustomCarID", "CustomCarDescription"); // selectedInt is not required
      return View(model);
    }
    [HttpPost]
    public ActionResult UnregisteredSection(CustomCar model)
    {
      // model.CustomCarsList contains the value of the selected option
    }
