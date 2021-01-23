    public abstract MyBaseController
    {
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                 ViewBag.LoginModel = /* add data here */;
            }
    }
