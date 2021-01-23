    private class MyCacheInterceptor : IInterceptor 
    {   
        public void Intercept(IInvocation invocation) {
            var attribute = (MyCacheAttribute)invocation.GetConcreteMethod()
                .GetCustomAttribute(typeof(MyCacheAttribute));
    
            if (attribute == null) {
                // Calls the decorated instance.
                invocation.Proceed();
            } else {
               // caching here
            }
        }
    }
