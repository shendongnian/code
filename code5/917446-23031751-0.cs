    public class ServiceSingletonConvention : DefaultConventionScanner
    {
        public override void Process(Type type, Registry registry)
        {
            base.Process(type, registry);
            if (type.IsInterface || !type.Name.ToLower().EndsWith("service")) return;
            var pluginType = FindPluginType(type); // This will get the interface
            registry.For(pluginType).Singleton().Use(type);
        }
    }
