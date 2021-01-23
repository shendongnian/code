    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var parameters = filterContext.ActionDescriptor.GetParameters();
    
        foreach (var parameter in parameters)
        {
            if (filterContext.ActionParameters.ContainsKey(parameter.ParameterName))
            {
                object value = filterContext.ActionParameters[parameter.ParameterName];
                        
                if (value == null)
                {
                     // The below line will fail if the model does not contain a default constructor.
                     value = Activator.CreateInstance(parameter.ParameterType);                          
                     filterContext.ActionParameters[parameter.ParameterName] = value;
                }
            }                
        }
    
        base.OnActionExecuting(filterContext);
    }
