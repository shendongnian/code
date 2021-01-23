    public class Selector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var attributes = type.GetMethod(method.Name).GetCustomAttributes(false);
            if (attributes.OfType<Retry>().Any())
            {
                // return retry interceptor
            }
            else
            {
                // return no interceptor
            }
        }
    }
