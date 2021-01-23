    abstract class ServiceBase
    {
        public abstract InstanceBase Instance { get; set; }
        public InstanceBase GetObject() //you can make the return type even 'T'
        {
            Instance.Method();
            return Instance;
        }
    }
    
    class ServiceA : ServiceBase 
    {
        public override InstanceBase Instance { get; set; } //return new InstanceA() here
    }
    
    class ServiceB : ServiceBase
    {
        public override InstanceBase Instance { get; set; } //return new InstanceB() here
    }
