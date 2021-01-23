    public class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly IContainer _container;
        public StructureMapSignalRDependencyResolver(IContainer container)
        {
            _container = container;
        }
        public override object GetService(Type serviceType)
        {
            return _container.TryGetInstance(serviceType) ?? base.GetService(serviceType);
        }
        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var objects = _container.GetAllInstances(serviceType).Cast<object>();
            return objects.Concat(base.GetServices(serviceType));
        }
    }
