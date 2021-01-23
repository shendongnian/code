    public void OnAuthorization(AuthorizationContext filterContext)
    {
        if (!filterContext.HttpContext.Request.IsAjaxRequest())
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated && 
                filterContext.ActionDescriptor.ActionName != "LogOut")
            {
                //Code Here
            }
        }
    }
