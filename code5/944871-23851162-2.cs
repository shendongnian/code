    public class MyService
    {   
        IDependentObject _dependentObject;
        readonly IDependentObjectFactory _factory;    
    
        //in general, when using DI, you should only have a single constructor on your injectable classes. Otherwise, you are at the mercy of the framework as to which signature it will pick if there is ever any ambiguity; most all of the common frameworks will make different decisions!
        public MyService(IDependentObjectFactory factory)
        {
           _factory=factory;
        }
    
        public void DoAThing(int clientID)
        {    
             var dependent  _factory.GetDependentObject(clientID);
             dependent.DoSomething();
        }
    }
