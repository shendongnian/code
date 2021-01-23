    public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
     var model = filterContext.ActionParameters.SingleOrDefault(ap => ap.Key == "uid").Value;
        
        
           if (model != null)
           {
              dosomething(id, name, uid)
           }
    }
