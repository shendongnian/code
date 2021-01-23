    abstract class A
    {
        public abstract List<T> BuildInfoPacket<T>(string someInput) where T : new();
    }
    
    class B : A
    {
        public override List<T> BuildInfoPacket<T>(string someInput)
        {
            // code implementation
            return new List<T> { new T() };
        }
    
        public void Test()
        {
            BuildInfoPacket<object>("test");
        }
    }
