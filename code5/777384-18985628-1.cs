    class MyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers["some_key"] != null
    && filterContext.HttpContext.Request.Headers.GetValues("some_key").First() == "hello")
            {
    
            }
        }
    }
