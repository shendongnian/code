    string ip = String.Empty;
    var props = OperationContext.Current.IncomingMessageProperties;
    var endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
    if (endpointProperty != null)
     {
          ip = endpointProperty.Address;
     }
