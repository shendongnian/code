	public interface IGraphicsInterfaceAdapter
	{
		// Extract all public properties of GraphicsInteface and define them here.
	}
	
	public class GraphicsInterfaceAdapter : IGraphicsInterfaceAdapter
	{
		public GraphicsInterfaceAdapter(VideoDevice device, FeatureLevel featureLevel)
			: base(device, featureLevel)
		{
		}
	}
