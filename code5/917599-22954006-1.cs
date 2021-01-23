    public ActionResult Index() --> Get Action of Index
    {
       ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
    
       return View();
    }
    
    [HttpPost]
    public string Index(FormCollection fc) --> Triggers when you click a button (POST action)
    {
        return "In post Index";
    }
