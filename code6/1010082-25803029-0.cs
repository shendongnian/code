    public  void OnActionExecuted( ActionExecutedContext filterContext)
    {
      try
      {
       var actionName = filterContext.ActionDescriptor.ActionName;
       var actionParams = filterContext.ActionDescriptor.GetParameters
       var actionParamsTypes = actionParams.Cast<ParameterDescriptor>()
                                           .Select(x => x.ParameterType).ToArray();
       var controllerType = filterContext.Controller.GetType();            
       var actionMethodInfo = controllerType.GetMethod(actionName,
                                                    actionParamsTypes, 
                                                    null);            
       var IsHttpPost = actionMethodInfo.IsDefiend(typeof(HttpPostAttribute),false);
    
       if(IsHttpPost) // checking if it is HttpPost
         {
            // do something
         }
       }
      catch (Exception ex)
      {
      }
    
    }
