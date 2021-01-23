	public class ProxyCustomAttributeBuilderDescriptor : IComponentModelDescriptor
	{
		public void BuildComponentModel(IKernel kernel, ComponentModel model)
		{
			var options = model.ObtainProxyOptions();    
            // ... do whatever you need to customise the proxy generation options
        }
		public void ConfigureComponentModel(IKernel kernel, ComponentModel model)
		{
		}
	}
