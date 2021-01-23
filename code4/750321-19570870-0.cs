    // controller constructor
    public MyController() {
        // grab action from RequestContext
        string action = System.Web.HttpContext.Current.Request.RequestContext.RouteData.GetRequiredString("action");
        // grab session (another example of using System.Web.HttpContext static reference)
        string sessionTest = System.Web.HttpContext.Current.Session["test"] as string
    }
