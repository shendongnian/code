    public class MyCacheInterceptor : IInterceptor 
    {   
        public void Intercept(IInvocation invocation) {
            // NOTE: bit naive implementation to fetch the called method
            var m = invocation.GetConcreteMethod();
            var method = invocation.InvocationTarget.GetType().GetMethod(m.Name);
            var attribute = method.GetCustomAttribute<MyCacheAttribute>();
    
            if (attribute == null) {
                // Pass through without applying caching
                invocation.Proceed();
            } else {
               // apply caching here
            }
        }
    }
