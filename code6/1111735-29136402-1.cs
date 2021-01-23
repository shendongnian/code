    public ActionResult Edit(int ID)
    {
      ProductsViewModel model = new ProductsViewModel();
      model.CategoryList = new SelectList(db.Categories, "ID", "Name"); // adjust parameters to suit
      model.CategoryID = ?; // set this if you want an initial option displayed
      return View(model);
    }
