    [HttpGet]
    public ActionResult YourActionName()
    {
    	var model = new JobViewModel
    	{
    		Job = job,
    		FileManager = "some value",
    		Estimator = "some value",
    		ProjectManager = "some value"
    	};
        PopulateModel(model);
    	
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult YourActionName(JobViewModel model)
    {
    	if(ModelState.IsValid)
    	{
    		// do something...
    		return RedirectToAction("your success action");
    	}
    
    	PopulateModel(model);
    
    	return View(model);
    }
    
    private void PopulateModel(JobViewModel model)
    {
    	model.FileManagers = new SelectList(users, "Value", "Text", model.FileManager);
    	model.Estimators = new SelectList(users, "Value", "Text", model.Estimator);
    	model.ProjectManagers = new SelectList(users, "Value", "Text", model.ProjectManager);
    }
