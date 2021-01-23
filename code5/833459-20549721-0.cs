    routes.MapRoute(
       name: "MyController",
       url: "{someparameters}",
       defaults: new { Controller = "MyController", Action = "Index" });
    
    public ActionResult Index(string someparameters)
    {
        ...
        return View(); 
    }
