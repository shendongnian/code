    public class MyCacheInterceptor : IInterceptor 
    {   
        public void Intercept(IInvocation invocation) {
            var method = invocation.GetImplementationMethod();
            var attribute = method.GetCustomAttribute<MyCacheAttribute>();
    
            if (attribute == null) {
                // Calls the decorated instance.
                invocation.Proceed();
            } else {
               // caching here
            }
        }
    }
    public static class InvocationExtensions
    {
        public static MethodInfo GetImplementationMethod(this IInvocation invocation) {
            // NOTE: bit naive implementation
            var method = invocation.GetConcreteMethod();
            return invocation.InvocationTarget.GetType().GetMethod(method.Name);
        }
    }
