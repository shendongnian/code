    public class Bootstrapper : DefaultNancyBootstrapper
    {
    	protected override void ConfigureRequestContainer(
            TinyIoCContainer container, NancyContext context)
    	{
    		base.ConfigureRequestContainer(container, context);
    		container.Register<ICurrentRequest>(
              (c, o) => new CurrentRequest(context));
    	}
    	
    	private class CurrentRequest : ICurrentRequest
    	{
    		public CurrentRequest(NancyContext context)
    		{
    			this.Context = context;
    		}
    
    		public NancyContext Context { get; private set; }
    	}
    }
