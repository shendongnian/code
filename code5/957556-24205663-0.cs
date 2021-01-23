    public class IpFilterAttribute : Attribute, IOperationBehavior, IParameterInspector
        {
            public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
            {
                dispatchOperation.ParameterInspectors.Add(this);
            }
    
            public void AddBindingParameters(OperationDescription operationDescription,
                BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
            {
            }
    
            public void Validate(OperationDescription operationDescription)
            {
            }
    
            public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
            {
            }
    
            public object BeforeCall(string operationName, object[] inputs)
            {
                var clientEndpoint =
                    OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as
                        RemoteEndpointMessageProperty;
    
                throw new SecurityException(string.Format("Calling method '{0}' is not allowed from address '{1}'.",
                    operationName, clientEndpoint.Address));
    
                return null;
            }
        }
