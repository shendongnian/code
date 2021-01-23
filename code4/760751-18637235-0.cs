    public class SomeClass
    {
        public SomeClass(ISomeInterfaceFactory factory)
        {
            this.factory = factory;
        }
    
        protected ISomeInterface SomeProperty
        {
            get { return factory.GetSomeInterface(); }
        }
    
        public void SomeMethod()
        {
            // uses SomeProperty in calculations
        }
    }
    
    public interface ISomeInterfaceFactory
    {
        ISomeInterface GetSomeInterface();
    }
