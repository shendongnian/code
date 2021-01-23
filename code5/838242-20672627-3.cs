    PopulateLoginModelAttribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User != null && filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                 filterContext.Controller.ViewBag.LoginModel = /* add data here */;
            }
 
            this.OnActionExecuting(filterContext);
        }
    }
