    class Logger : IInterceptor
    {
        public void Intercept(IInvocation invocation) // implements the IInterceptor interface
        {
            using (var someThing = new SomeResource())
            {
                invocation.Proceed();
            }
        }
    }
