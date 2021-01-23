    public ActionResult Index()
    {
    	ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";	
    	Person p = new Person();
    	return View(p);
    }
    
    public void ModelBinding(Person p)
    {
    	// Perform action to process the request
    }
