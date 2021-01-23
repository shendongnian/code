    private bool ActionIsAccessibleToUser(string actionName, ControllerBase controllerBase)
    {
        // Get controller context.
        var controllerContext = new ControllerContext(this.ControllerContext.RequestContext, controllerBase);
        // Get controller descriptor.
        var controllerDescriptor = new ReflectedControllerDescriptor(controllerBase.GetType());
        // Get action descriptor.
        var actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
        // Check on authorization.
        return ActionIsAuthorized(actionDescriptor, controllerContext);
    }
    private bool ActionIsAuthorized(ActionDescriptor actionDescriptor, ControllerContext controllerContext)
    {
        if (actionDescriptor == null)
        {
            // Action does not exist.
            return false;
        }
        // Get authorization context fo controller.
        AuthorizationContext authContext = new AuthorizationContext(controllerContext, actionDescriptor);
        // run each auth filter until on fails
        // performance could be improved by some caching
        var filters = FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor);
        FilterInfo filterInfo = new FilterInfo(filters);
        foreach (IAuthorizationFilter authFilter in filterInfo.AuthorizationFilters)
        {
            // Attempt authorization.
            authFilter.OnAuthorization(authContext);
            // If result is non-null, user is not authorized.
            if (authContext.Result != null)
            {
                return false;
            }
        }
        // Assume user is authorized.
        return true;
    }
