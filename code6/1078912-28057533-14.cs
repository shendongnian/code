    public ActionResult Edit(int ID)
    {
      StudentVM model = new StudentVM();
      // populate your view model with values from the database
      return View(model);
    }
    [HttpPost]
    public ActionResult Edit(StudentVM model)
    {
      // save and redirect
    }
