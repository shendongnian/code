    [HttpPost]
    public ActionResult Index(AViewModel model)
    {
    	var isValid = model.DrpaActivity;
    	return View(model);
    }
