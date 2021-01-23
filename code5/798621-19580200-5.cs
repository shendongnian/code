    [CLSCompliant(false)]
    public class ProxyConvention : DefaultConventionScanner
    {
        public override void Process(Type type, Registry registry)
        {
            var interfacesToHandle = type.GetInterfaces()
                 .Where(i => i... // select what which interface should be mapped
            foreach (var inter in interfacesToHandle)
            {
                var setting = registry
                    .For(inter)
                    .HybridHttpOrThreadLocalScoped();
                    .Use(new ProxyInstance(type)); // here we go to inject wrapper
         ...
