	public interface IGraphicsFactory
	{
		GraphicsInterface Create(VideoDevice device);
		void Release(GraphicsInterface graphicsInterface);
	}
	public class GraphicsFactory : IGraphicsFactory
	{
		private readonly FeatureLevel featureLevel;
		// Parameters injected are done so by the DI container
		public GraphicsFactory(FeatureLevel featureLevel)
		{
			this.featureLevel = featureLevel;
		}
		
		// Parameters passed are part of the application runtime state
		public GraphicsInterface Create(VideoDevice device)
		{
			return new GraphicsInterface(device, this.featureLevel);
		}
		
		// Method for releasing disposable dependencies (if any)
		public void Release(GraphicsInterface graphicsInterface)
		{
			var disposable = graphicsInterface as IDisposable;
			if (disposable != null)
				disposable.Dispose();
		}
	}
