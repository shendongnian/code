    public ActionResult Edit()
    {
      LoanViewModel model = new LoanViewModel();
      model.Item = "Two"; // this will now pre-select the second option in the view
      ConfigureEditModel(model);
      return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(LoanViewModel model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureEditModel(model); // repopulate select list
        return View(model); // return the view to correct errors
      }
      // If you want to validate the the value is indeed one of the items
      ConfigureEditModel(model);
      if (!model.ItemList.Contains(model.Item))
      {
        ModelState.AddModelError(string.Empty, "I'm secure!");
        return View(model);
      }
      string selectedItem = model.Item;
      ....
      // save and redirect
    }
    private void ConfigureEditModel(LoanViewModel model)
    {
      List<string> items = new List<string>() { "One", "Two", "Three" };
      model.ItemList = new SelectList(items); // create the options
      // any other common stuff
    }
