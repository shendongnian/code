    public override void OnAuthorization(AuthorizationContext filterContext)
    {
        base.OnAuthorization(filterContext);
    
        if(filterContext.ActionDescriptor.ActionName == RedirectActionName && 
           filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == RedirectControllerName)
        {
            return;
        }
        
        ....
    }
