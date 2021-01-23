    public class A
    {
        private IUserBM userBm;
        public A(IUserBM userBm)
        {
            this.userBm = userBm;
        }
    
        public void DoSomething()
        {
            this.userBm.Work();
        }
    }
    
    // this will construct an instance of class A injecting required types
    var a = unityContainer.Resolve<A>();
    a.DoSomething();
