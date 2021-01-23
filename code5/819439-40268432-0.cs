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
    
    	public override SetContainer(IContainer container){
    		//Configure the desired rebus
    		var bus = Rebus.Config.Configure.With(new AutofacContainerAdapter(container));
    		
    		//Reconfigure rebus to support decorator
    		//Note: I want to improve this step!
    		var containerUpdate = new ContainerBuilder();
    
    				containerUpdate
    					  .RegisterInstance(bus)
    					  .SingleInstance()
    					  .Named<IBus>("Metadata");
    
    				containerUpdate.Update(container);
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
