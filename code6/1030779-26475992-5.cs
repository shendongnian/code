    [HttpPost]
    public ActionResult Index([Bind(Prefix="NewNote")]Notes model)
    {
      // Note you only have a control for `Test` so `ID` and `Time` will both be default values
      if (ModelState.IsValid)
      {
        db.Notes.Add(model);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(model);
    }
