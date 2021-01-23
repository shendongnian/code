    public interface IServiceHelperFactory
    {
        IServiceHelper CreateServiceHelper(string serviceName);
    }
    public class ServiceHelperFactory : IServiceHelperFactory
    {
        private IContainer container;
        public ServiceHelperFactory(IContainer container)
        {
            this.container = container;
        }
        
        public IServiceHelper CreateServiceHelper(string serviceName)
        {
            return container.Resolve<ServiceHelper>(new NamedParameter("serviceName", serviceName));
        }
    }
