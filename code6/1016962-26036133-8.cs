    [HttpPost]
    public ActionResult Index(AModel model)
    {
        //All the selected animals are available in the model
    	
    	return View(model);
    }
