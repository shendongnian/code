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
        Court court = db.Courts.Find(model.SelectedCourt) // get the Court based on `SelectedCourt`
        var parent = new Parent()
        {
          FirstName = model.FirstName,
          LastName = model.LastName,
          Court  = court
        };
        db.Parents.Add(parent);
        foreach (ChildVM item in viewModel.Children)
        {
          ....
          db.Childs.Add(child);
        }
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      model.CourtList = new SelectList(db.Courts, "CourtId", "CourtName"); // reassign select list
      return View(model);
    }
