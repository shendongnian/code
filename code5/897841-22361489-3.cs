    public class TestClass : TestInterface
    {
        public ClassX InterfaceX { get; private set; }
        InterfaceX TestInterface.InterfaceX { get { return InterfaceX; } }
    }
