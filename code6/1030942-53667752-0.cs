    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private readonly IContainer _container;
        private readonly Type _type;
        public StructureMapInstanceProvider(IContainer container, Type type)
        {
            _container = container;
            _type = type;
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return _container.GetInstance(_type);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            _container.Release(instance);
        }
    }
