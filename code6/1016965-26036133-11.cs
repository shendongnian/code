    [HttpPost]
    public ActionResult Index(AModel model)
    {
        //All the selected countries are available in the model
    	
    	return View(model);
    }
