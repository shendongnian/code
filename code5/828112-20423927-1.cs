    protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
    {
        if (filterContext.HttpContext.Request.IsAuthenticated)
        {
            
            filterContext.HttpContext.Session["OpenAuthorizationPopup"] =  "true";
                    
            filterContext.Result = new RedirectResult(filterContext.Controller.TempData["urlOrigen"].ToString());
            
        }
        else
        {
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
