    public class Interceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
           try{
                invocation.Proceed();
            } catch(Exception ex) {
               //add your "post execution" calls on the invocation's target
            }
        }
    }
