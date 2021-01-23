    // custom self timing for any wcf operation
        public class Timing :Attribute, IOperationBehavior,  IOperationInvoker 
        { 
            IOperationInvoker innerOperationInvoker;
            private string operName = "";
    
            public Timing()
            {
            }
    
            public Timing(IOperationInvoker innerOperationInvoker, string name)
            {
                this.innerOperationInvoker = innerOperationInvoker;
                operName = name;
            }
    
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                dispatchOperation.Invoker = new Timing(dispatchOperation.Invoker, operationDescription.Name);
            }
    
            public object Invoke(object instance, object[] inputs, out object[] outputs)
            {
                object value;
        
                var sw = new Stopwatch();
                sw.Start();
                value = innerOperationInvoker.Invoke( instance, inputs, out outputs);
                sw.Stop();
                // do what you need with the value...
                Trace.WriteLine(String.Format("{0}: {1} ms", operName,  sw.ElapsedMilliseconds));
                return value;
            }
    
    
            // boring required interface stuff
    
            public object[] AllocateInputs()
            {
                return innerOperationInvoker.AllocateInputs();
            }
    
            public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
            {
                return innerOperationInvoker.InvokeBegin(instance, inputs, callback, state);
            }
    
            public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
            {
                return innerOperationInvoker.InvokeEnd(instance, out outputs, result);
            }
    
            public bool IsSynchronous
            {
                get { return innerOperationInvoker.IsSynchronous; }
            }
    
            public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
            {
                // throw new NotImplementedException();
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
                // throw new NotImplementedException();
            }
    
            public void Validate(OperationDescription operationDescription)
            {
                // throw new NotImplementedException();
            }
        }
