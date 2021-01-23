    public abstract class ManagerFactory<TManager, TManaged> 
        where TManager : IBaseManager<TManaged>, new()
        where TManaged : IBaseManaged<TManager>, new()
    {
        TManager manager = new TManager ();
        ManagedRegister<TManaged> registered = new ManagedRegister<TManaged> ();
        public ManagerFactory () {
            manager.Registered = registered;
        }
        public TManaged CreateManaged (string name)
        {
            TManaged result = new TManaged();
            result.Name = name;
            registered.Add (result.Name, result);
            result.Manager = manager;
            return result;
        }
    }
    public class ConcreteFactory : ManagerFactory<ConcreteManager, ConcreteManaged>
    {}
