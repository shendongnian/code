    public abstract class ManagedFactory<TManager, TManaged> 
        where TManager : IBaseManager<TManaged>, new()
        where TManaged : IBaseManaged<TManager>, new()
    {
        TManager manager = new TManager ();
        public ManagedFactory () {
            manager.Registered = new ManagedRegister<TManaged> ();
        }
        public virtual TManager Manager { get { return manager; } }
        public virtual TManaged CreateManaged (string name)
        {
            TManaged result = new TManaged();
            result.Name = name;
            manager.Registered.Add (result.Name, result);
            result.Manager = manager;
            return result;
        }
    }
    public class ConcreteFactory : ManagedFactory<ConcreteManager, ConcreteManaged>
    {}
