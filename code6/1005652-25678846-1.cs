    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      ...
      var reflectedActionDescriptor = actionContext.ActionDescriptor as ReflectedHttpActionDescriptor;
      if (reflectedActionDescriptor != null)
      {
        // get the custom attributes applied to the action return value
        var attrs = reflectedActionDescriptor
                      .MethodInfo
                      .ReturnTypeCustomAttributes
                      .GetCustomAttributes(typeof (SafeAttribute), false)
                      .OfType<SafeAttribute>()
                      .ToArray();
      }
      ...
    }
