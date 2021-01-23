    public class SharedClass
    {
        private readonly IRegionCode m_RegionLogic;
        // Constructor with dependency injection
        public SharedClass(IRegionCode mRegionLogic)
        {
            this.m_RegionLogic = mRegionLogic;
        }
       
        // Method called by the webservice
        public void YourMethod()
        {
            // reused base logic here
            Trace.Write("Somehting");
            // Invoke region specific code
            m_RegionLogic.Foo();
            // reused base logic here
            Trace.Write("Somehting");
        }
    }
    // Contract for regions to implement
    public interface IRegionCode
    {
        void Foo();
    }
    // Example of an injected class
    public class FirstRegionCode : IRegionCode
    {
        public void Foo()
        {
            Trace.Write("Bar");
        }
    }
