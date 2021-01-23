    MessageProperties props = OperationContext.Current.IncomingMessageProperties;
    
    RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)props[RemoteEndpointMessageProperty.Name];
     
    string addr = prop.Address;
    int iPort   = prop.Port;
