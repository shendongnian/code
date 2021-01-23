    public ActionResult Create()
    {
      ParentVM model = new ParentVM()
      {
        Children = new List<ChildVM>() .....,
        CourtList = new SelectList(db.Courts, "CourtId", "CourtName"),
        SelectCourt = // set a value here if you want a specific option to be selected
      });
      return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ParentVM model)
    {
      if (ModelState.IsValid)
      {
        // model.SelectedCourt contains the selected CourtId value
        // map from view model to model, save and redirect
      }
      model.CourtList = new SelectList(db.Courts, "CourtId", "CourtName"); // reassign select list
      return View(model);
    }
