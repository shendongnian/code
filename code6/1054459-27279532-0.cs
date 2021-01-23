    public class TaskInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var task = invocation.ReturnValue as Task;
            InterceptBeforeInvoking();
            invocation.Proceed();
            task.ContinueWith(InterceptAfterInvocation);
        }
        private void InterceptAfterInvocation(Task obj)
        {
            
        }
        private void InterceptBeforeInvoking()
        {
            
        }
    }
