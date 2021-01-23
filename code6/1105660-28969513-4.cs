    public class MyCacheInterceptor : IInterceptor 
    {   
        public void Intercept(IInvocation invocation) {
            var attribute = invocation.Method.GetAttribute<MyCacheAttribute>();
    
            if (attribute == null) {
                // Pass through without applying caching
                invocation.Proceed();
            } else {
               // apply caching here
            }
        }
    }
