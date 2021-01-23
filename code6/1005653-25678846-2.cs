    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      ...
      ReflectedHttpActionDescriptor reflectedActionDescriptor;
      
      // Check whether the ActionDescriptor is wrapped in a decorator or not.
      var wrapper = actionContext.ActionDescriptor as IDecorator<HttpActionDescriptor>;
      if (wrapper != null)
      {
        reflectedActionDescriptor = wrapper.Inner as ReflectedHttpActionDescriptor;
      }
      else
      {
        reflectedActionDescriptor = actionContext.ActionDescriptor as ReflectedHttpActionDescriptor;
      }
      
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
