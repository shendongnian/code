    public override void RegisterArea(AreaRegistrationContext context) 
    {
    	context.MapRoute(
    		"Test_default",
    		"Test/{controller}/{action}/{id}",
    		new { action = "Index", id = UrlParameter.Optional },
    		namespaces: new[] { "YourNamespace.YourApplication.Areas.Test.Controllers" }
    	);
    }
