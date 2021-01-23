        Your answer is Routing.
        
        http://msdn.microsoft.com/en-us/library/cc668201.aspx
        
        you will have to make changes to:
        
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new Route`enter code here`
            (
                 "Category/{action}/{categoryName}"
                 , new CategoryRouteHandler()
            ));
        }
    
    
    
    ------------
    
    
    Hi Moksh, 
    Was busy the whole day.
    
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
