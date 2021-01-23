    [ServiceContract]
    public interface IMasterInterface : InterfaceA, InterfaceB
    {
    }
    
    public class MasterClass : IMasterInterface
    {
        public MasterClass()
        {
            aInstance = new DllA.clientA();
            bInstance = new DllB.clientB();
        }
    
        DllA.InterfaceA aInstance; //Use full namespaces to prevent conflicts.
        DllB.InterfaceB bInstance;
    
        public void DllA.InterfaceA.Foo() //Use explicit interfaces to prevent name conflicts
        {
            aInstance.Foo();
        }
    
        public bool DllB.InterfaceB.Foo()
        {
           return bInstance.Foo();
        }
    }
