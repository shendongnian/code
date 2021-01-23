    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var controller = filterContext.Controller as BaseController;
        
        // IController is not necessarily a Controller
        if (controller != null)
        {
            ALM_APP objALM_APP = new ALM_APP();
            objALM_APP = DalContext.getAppInformation();
    
            controller.ViewBag.ApplicationName = objALM_APP.ApplicationName;
            controller.ViewBag.AppVersion = objALM_APP.Version;
        
         }
    }
