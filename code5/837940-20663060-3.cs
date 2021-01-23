    abstract class ServiceBase
    {
        public abstract InstanceBase Instance { get; }
        public InstanceBase GetObject() //you can make the return type even 'T'
        {
            Instance.Method();
            return Instance;
        }
    }
    
    class ServiceA : ServiceBase 
    {
        public override InstanceBase Instance { get; } //return new InstanceA() here
    }
    
    class ServiceB : ServiceBase
    {
        public override InstanceBase Instance { get; } //return new InstanceB() here
    }
