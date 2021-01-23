    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        HttpCookie externalUserCookie = filterContext.HttpContext.Request.Cookies["ExternalUser"];
        if (externalUserCookie != null)
        {
            // 1. Security Questions
            if (externalUserCookie["ForceQA"] == "1")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary 
                    { 
                        { "controller", "MyInfo" }, 
                        { "action", "ChangeSecurityQuestions" } 
                    });
                return;
            }
            // 2. Password Reset
            if (externalUserCookie["ForcePass"] == "1")
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary 
                    { 
                        { "controller", "MyInfo" }, 
                        { "action", "ChangePassword" } 
                    });
                return;
            }
        }
        // If we made it here, pass the call on to the action method
        base.OnResultExecuting(filterContext);
    }
