    public class ManagerFactory // register it in container
    {
       public IManager<T> Create<T>(IProvider provider) { return ... }
    }
    
    public class Processor<T>
    {
        public Processor(ManagerFactory factory, IEnumerable<IProvider> providers)
        {
           myManagers = providers.Select(provider => factory.Create<T>(provider).ToList();
        }
    }
