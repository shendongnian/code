    public class BarInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method.Name == "get_bar")
            {
                var hasBarBackingField = invocation.InvocationTarget as IHasBarBackingField;
                invocation.ReturnValue = hasBarBackingField.RetrieveBar();
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
