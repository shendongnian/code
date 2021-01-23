    public class ModifyStringMethodInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            if (invocation.Method.Name.StartsWith("get_") && 
                invocation.Method.ReturnType == typeof(string))
            {
                invocation.ReturnValue = 
                  ModifyStringMethod((string)invocation.ReturnValue);
            }
        }
        private static string ModifyStringMethod(string input)
        {
            return (input ?? "") + "MODIFIED";
        }
    }
