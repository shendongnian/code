    public class ErrorLoggingOperationInvokerFacade : IOperationInvoker
    {
        private readonly IOperationInvoker _invoker;
        private readonly ILog _log;
    
        public ErrorLoggingOperationInvokerFacade(IOperationInvoker invoker, ILog log)
        {
            _invoker = invoker;
            _log = log;
        }
    
        public object[] AllocateInputs()
        {
            return _invoker.AllocateInputs();
        }
    
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            return _invoker.Invoke(instance, inputs, out outputs);
        }
    
        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            return _invoker.InvokeBegin(instance, inputs, callback, state);
        }
    
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            var task = result as Task;
            if (task != null && task.IsFaulted && task.Exception != null)
            {
                foreach (var error in task.Exception.InnerExceptions)
                {
                    _log.Log(error);
                }
            }
    
            return _invoker.InvokeEnd(instance, out outputs, result);
        }
    
        public bool IsSynchronous { get { return _invoker.IsSynchronous; } }
    }
