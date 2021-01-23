     public override void OnAuthorization(AuthorizationContext filterContext)
     {
        
        //Some logic here...
        filterContext.Result = new RedirectToRouteResult(
                               new RouteValueDictionary(
                               new { controller = "Account",
                                                 action = "Login", 
                                                 ReturnUrl = filterContext.HttpContext.Request.RawUrl }));            
     }
