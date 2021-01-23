    public class ContainerJobActivator : JobActivator
    {
        private readonly IContainer _container;
        private static readonly string JobContextGenericTypeName = typeof(JobContext<>).ToString();
        public ContainerJobActivator(IContainer container)
        {
            _container = container;
        }
        public override object ActivateJob(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().ToString() == JobContextGenericTypeName)
            {
                var scope = _container.BeginLifetimeScope();
                var context = Activator.CreateInstance(type);
                var propertyInfo = type.GetProperty("Scope");
                propertyInfo.SetValue(context, scope);
                return context;
            }
            return _container.Resolve(type);
        }
    }
