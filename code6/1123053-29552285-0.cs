    public ActionResult Index()
    {
        ViewBag.Message = "Welcome to ASP.NET MVC!";
	    var list = new List<Docs>();
	    // deserialize json into list
        return View(list);
    }
