    public class CustomTracerPlugin : IRuntimePlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {
        }
        public void RegisterCustomizations(ObjectContainer container, RuntimeConfiguration runtimeConfiguration)
        {
            container.RegisterTypeAs<CustomTracer, ITestTracer>();
        }
        public void RegisterConfigurationDefaults(RuntimeConfiguration runtimeConfiguration)
        {
        }
    }
