    public interface IFactory<T>
    {
        T Retrieve(string domain);
    }   
    internal sealed class Factory<T> : IFactory<T>
    {
        private readonly IUnityContainer _container;
        public Factory(IUnityContainer container)
        {
            _container = container;
        }
        public T Resolve(string domain)
        {
            // this is actually more complex - we have chain inheritance here
            // for simplicity assume service is either registered for given 
            // domain or it throws an error
            return _container.Resolve<T>(domain);
        }
    }
    // bootstrapper
    var container = new UnityContainer();
    container.RegisterType<IService, CoreService>();
    container.RegisterType<IService, GermanService>("german.site.com");
    container.RegisterType<IService, UsaService>("usa.site.com");
    container.RegisterInstance<IFactory<IService>>(new Factory<IService>(container));    
    
