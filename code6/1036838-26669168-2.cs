        Your answer is Routing.
        
        http://msdn.microsoft.com/en-us/library/cc668201.aspx
        
      
    
    Look at following code :
    
     public ActionResult Test()
            {
                ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
    
                return RedirectToAction("TestAspx");
            }
    
    
            public ActionResult TestAspx()
            {
                ViewBag.Message = "Your app Test aspx page.";
    
                return View();
            }
    
    
    Here the action TestAspx() returns an TestAspx.aspx view.
    
    And for the Routing 
    
    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                  "TestAspx",
                  "testganesh",
                  new { controller = "Home", action = "TestAspx" }
                  );
    
    
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                    );
    
              
            }
    
    Please make appropriate changes to the routing names that you need.
    
    Hope this will help.
    
    Let me know if you still face any issue.
    
    Mark as right if the issue got fixed.
    :)
