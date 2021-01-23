    public class RebusConfig  {
    
    	protected override void Load(ContainerBuilder builder)
    	{
    		//Autofac configuration to decorate Rebus
    		builder.RegisterDecorator<IBus>(
    					(c, inner) => new RebusMetadataDecorator(
    							inner, c.Resolve<HttpRequestMessage>()),
    					fromKey: "Metadata")
    					 .InstancePerRequest();
    					 
    	}					
    }			
    
    //Rebus Decorator 				
    public class RebusMetadataDecorator : IBus
    {
    		private  HttpRequestMessage requestMessage;
            private  IBus bus;
    		
    		public RebusMetadataDecorator(
                IBus bus, HttpRequestMessage requestMessage)
            {
                this.requestMessage = requestMessage;
                this.bus = bus;
            }
    	
    		public void Publish<TEvent>(TEvent message)
            {
                SetHttpMetadataToHeader(bus, message, metadataProvider, prefix);
                bus.Publish<TEvent>(message);
            }
    }
