     [CustomAuthorize]
            public ActionResult Index()
            {
               var http = this.HttpContext;
               String UserID = http.User.Identity.Name; 
                return View();
            }
    
    
    
      public class CustomAuthorize : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                return true;
            }
        }
