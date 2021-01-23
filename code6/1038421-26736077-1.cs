    //_serviceHost is ServiceHost.ServiceHost type
    ContractDescription cd = _serviceHost.Description.Endpoints[0].Contract;
    
    //the string is the name of operation for which you can do the custom (de)serialization
    cd.Operations.Find("GetData")
    
    DataContractSerializerOperationBehavior serializerBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
    if (serializerBehavior == null)
    {
        serializerBehavior = new DataContractSerializerOperationBehavior(operation);
        operation.Behaviors.Add(serializerBehavior);
    }
    
    serializerBehavior.DataContractResolver = new MyResolver();
    
    //Now you can start listening by _serviceHost.Open()
