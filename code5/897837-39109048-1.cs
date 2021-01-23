    public class CustomTracerPlugin : IRuntimePlugin
	{
		public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
		{
			runtimePluginEvents.CustomizeTestThreadDependencies += (sender, args) => { args.ObjectContainer.RegisterTypeAs<CustomTracer, ITestTracer>(); };
		}
	}
