    public ActionResult Edit()
    {
      MyModel model = new MyModel();
      model.date-desc = "date-desc"; // set default
      return View(model)
    }
    public ActionResult Edit(MyModel model)
    {
      .... // model is correctly bound with selected values
