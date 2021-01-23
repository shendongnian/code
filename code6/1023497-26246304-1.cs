    public ActionResult Create()
    {
        CommentModelVM model = new CommentModelVM();
        ConfigureViewModel(model);
        return View(model);
    }
    public ActionResult Create(CommentModelVM model)
    {
      if (!ModelState.IsValid())
      {
        // Repopulate options and return view
        ConfigureViewModel(model);
        return View(model);
      }
      // Save and redirect
    }
    private void ConfigureViewModel(CommentModelVM model)
    {
      List<string> departments = // create your list of departments here (from database or static list)
      model.DepartmentList = new SelectList(departments);
    }
