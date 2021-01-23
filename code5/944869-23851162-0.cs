    public class NormalDependentObject:INormalDependentObject
    {
        readonly int _clientID;
        public DependentObject(int clientID)
        {
           _clientID=clientID;
        }
        public void DoSomething(){//do something}
    }
    
    public class DependentObject:ISpecialDependentObject
    {
        readonly int _clientID;
        public DependentObject(int clientID)
        {
           _clientID=clientID;
        }
        public void DoSomething(){//do something really special}
    }
