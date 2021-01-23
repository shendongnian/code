    public class MyServiceProxy : System.ServiceModel.DuplexClientBase<IMyService>, IMyService
    {
    	public MyServiceProxy(InstanceContext callbackInstance, Binding binding, EndpointAddress remoteAddress)
    		: base(callbackInstance, binding, remoteAddress)
    	{
    		ContractDescription cd = this.Endpoint.Contract;
    
    		//the string is the name of operation for which you can do the custom (de)serialization
    		cd.Operations.Find("GetData")
    		
    		DataContractSerializerOperationBehavior serializerBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
    		if (serializerBehavior == null)
    		{
    			serializerBehavior = new DataContractSerializerOperationBehavior(operation);
    			operation.Behaviors.Add(serializerBehavior);
    		}
    		
    		serializerBehavior.DataContractResolver = new MyResolver();
    	}
    	
    	...
    	
    }
