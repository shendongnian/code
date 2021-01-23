	public class SomeService : ISomeService
	{
		private readonly IGraphicsFactory graphicsFactory;
		
		public SomeService(IGraphicsFactory graphicsFactory)
		{
			if (graphicsFactory == null)
				throw new ArgumentNullException("graphicsFactory")
				
			this.graphicsFactory = graphicsFactory;
		}
		
		public void DoSomething()
		{
			// Get video device here. It will likely be best to 
			// delegate that to another specialized service
			// that is injected into this class.
			VideoDevice device = ...;
			
			var graphics = this.graphicsFactory.Create(device);
			try
			{
				// Do something with graphics
			}
			finally
			{
				this.graphicsFactory.Release(graphics);
			}
		}
	}
