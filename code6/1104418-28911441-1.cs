    protected override void OnAuthorization(AuthorizationContext filterContext)
    {
        AuthorizationManager authorizationManager = new AuthorizationManager();
    
        string FilePath = Convert.ToString(filterContext.HttpContext.Request.FilePath);
    
        if (!authorizationManager.IsAuthorized(_userSession, FilePath))
        {
            RedirectToControllers(ControllerHelper.Controller.ACCOUNT, ControllerHelper.Controller.Action.ACCOUNT_LOGIN);
        
            break; // use this
            return; // or this
            // 1. Need to stop excution process from here. 
            // 2. No need to excute any line of code from here.
        }
     }
