    class CustomExceptionHandler : ICallHandler
    {
      public IMethodReturn Invoke(IMethodInvocation input,
        GetNextHandlerDelegate getNext)
      {
        WriteLog(String.Format("Invoking method {0} at {1}",
          input.MethodBase, DateTime.Now.ToLongTimeString()));
    
        // Invoke the next handler in the chain
        var result = getNext().Invoke(input, getNext);
    
        // After invoking the method on the original target
        if (result.Exception != null)
        {
          // This could cause an exception if the Type is invalid
          result.ReturnValue = -1;
          result.Exception = null;    
        }
    
        return result;
      }
    
      public int Order
      {
        get;
        set;
      }
    }
    class CustomExceptionHandlerAttribute : HandlerAttribute
    {
      private readonly int order;
    
      public CustomExceptionHandlerAttribute(int order)
      {
        this.order = order;
      }
    
      public override ICallHandler CreateHandler(IUnityContainer container)
      {
        return new CustomExceptionHandler() { Order = order };
      }
    }
    class TenantStore : ITenantStore
    {
        [CustomExceptionHandler(1)]
        public int Process()
        {
            throw new Exception("TEST");
        }
    }
    container.RegisterType<ITenantStore, TenantStore>(
        new InterceptionBehavior<PolicyInjectionBehavior>(),
        new Interceptor<InterfaceInterceptor>());
