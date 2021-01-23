    interface IManagerFactory<TManager, TManaged> 
        where TManager : IBaseManager<TManaged>
        where TManaged : IBaseManaged<TManager> 
    {
        TManager Manager { get; }
        TManaged Create (string name);
    }
    public abstract class ManagerFactory<TManager, TManaged> 
        : IManagerFactory<TManager, TManaged> 
        where TManager : IBaseManager<TManaged>, new()
        where TManaged : IBaseManaged<TManager>, new()
    {
        TManager manager = new TManager ();
        public ManagerFactory () {
	        manager.Registered = new ManagedRegister<TManaged> ();
        }
        public TManager Manager { get { return manager; } }
        public TManaged Create (string name)
        {
	        TManaged result = new TManaged ();
	        result.Name = name;
	        manager.Registered.Add (result.Name, result);
	        result.Manager = manager;
	        return result;
        }
    }
    public class ConcreteFactory 
        : ManagedFactory<ConcreteManager, ConcreteManaged> { }
