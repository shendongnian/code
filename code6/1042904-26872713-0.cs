    public override void OnActionExecuting(HttpActionContext actionContext)
     {
      if (actionContext.ActionArguments.ContainsKey("value") && actionContext.ActionArguments["value"] is InputObject)
      {
        var val = actionContext.ActionArguments["value"] as InputObject;
        val.Parameter = "value";
      }
        
      base.OnActionExecuting(actionContext);
    }
