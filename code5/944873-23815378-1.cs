    public ActionResult ShowMyModel()
    {
      var model = new MyModel(); // or Respository.GetMyModel() whatever..
      View(model);
    }
    public ActionResult ValidateModel(MyModel_ValidateMystringOnly model)
    {
      if (ModelState.IsValid)
      {
        // Hey Validation!
      }
      // MyModel_ValidateMyStringOnly is a MyModel 
      // so it can be passed to the same view!
      return View("ShowMyModel", model);
    }
