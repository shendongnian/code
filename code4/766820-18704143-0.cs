    public ActionResult Create()
    {
    	var model = new SubjectModel();
    	PopulateSubjectList(model);
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult Create(SubjectModel model)
    {
    	if (ModelState.IsValid)
    	{
    		// Save item..
    	}
    	// Something went wrong.
    	PopulateSubjectList(model);
    	return View(model);
    }
    
    private void PopulateSubjectList(SubjectModel model)
    {
    	model.Subjects = _db.Subjects.ToList();
    }
