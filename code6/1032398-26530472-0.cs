    [HttpGet]
    public ActionResult MyAction(string myString) 
    {
    	var model = new MyActionModel();
    	// do some stuff
    	return View(model);
    }
    
    [HttpPost]
    public ActionResult MyAction(string myString, MyActionModel model) 
    {
    	// do different stuff
    	return View(model);
    }
