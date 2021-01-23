    public ActionResult Index()
    {
        ViewBag.Name = "Monjurul Habib";
        return View();
    }
    
    public ActionResult Index()
    {
        ViewData["Name"] = "Monjurul Habib";
        return View();
    } 
