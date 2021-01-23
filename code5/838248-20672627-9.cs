    public abstract MyBaseController : Controller
    {
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                 if (User != null && User.Identity.IsAuthenticated) // check if user is logged in if you need to
                 {
                      ViewBag.LoginModel = /* add data here */;
                 }
            }
    }
