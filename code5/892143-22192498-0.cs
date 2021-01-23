    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       if(filterContext.HttpContext.Request.HttpMethod == "POST")
       {
          // Do nothing
       }
       else
       {
           //Do Something
       }
    }
