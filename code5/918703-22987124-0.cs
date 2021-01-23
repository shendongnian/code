    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        object model = filterContext.ActionParameters
                                    .TryGetValue("model", out model) 
                                    ? model : null;
        if (model != null)
        {
            var logModel = model as Log;
            if (logModel != null)
            {
                logModel.Date = DateTime.Now;
                logModel.Username = filterContext.HttpContext.User.Identity.Name;
            }
        }
    }
