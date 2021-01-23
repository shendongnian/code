    [assembly: RuntimePlugin(typeof(CustomTracer.SpecflowPlugin.CustomTracerPlugin))]
    
    namespace CustomTracer.SpecflowPlugin
    {
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
    
        public class CustomTracer : ITestTracer
        {
            // Your implementation here
        }
    }
