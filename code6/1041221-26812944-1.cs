    public ActionResult Edit()
    {
      List<string> items = new List<string>() { "One", "Two", "Three" };
      LoanViewModel model = new LoanViewModel();
      model.Item = "Two"; // this will now pre-select the second option in the view
      model.ItemList = new SelectList(items); // create the options
      return View(model);
    }
    public ActionResult Edit(LoanViewModel model)
    {
      string selectedItem = model.Item;
      ....
    }
