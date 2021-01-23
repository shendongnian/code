    public override void OnActionExecuting(HttpActionContext actionContext)
    {
         var parameters = actionContext.ActionDescriptor.GetParameters();
    
         foreach (var parameter in parameters)
         {
             object value = null;
    
             if (actionContext.ActionArguments.ContainsKey(parameter.ParameterName))
                 value = actionContext.ActionArguments[parameter.ParameterName];
    
             if (value != null)
                continue;
    
             value = CreateInstance(parameter.ParameterType);
             actionContext.ActionArguments[parameter.ParameterName] = value;
         }
    
         base.OnActionExecuting(actionContext);
    }
    
    protected virtual object CreateInstance(Type type)
    {
       // Check for existence of default constructor using reflection if needed
       // and if performance is not a constraint.
   
       // The below line will fail if the model does not contain a default constructor.
       return Activator.CreateInstance(type);
    }
