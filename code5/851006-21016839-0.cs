    public class ValidationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (invocation.Method.IsSpecialName && invocation.Method.Name.StartsWith("set_"))
            {
                invocation.InvocationTarget.Validate();
            }
        }
    }
