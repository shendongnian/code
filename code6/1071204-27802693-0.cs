    public interface IEngine
    {
        void Foo();
    }
    
    public interface IEngine2 : IEngine
    {
        void Goo();
    }
    
    public class EngineA : IEngine
    {
        public void Foo()
        {
            //...
        }
    }   
    
    public class EngineB : IEngine2
    {
        public void Foo()
        {
            //...
        }
    
        public void Goo()
        {
            //...
        }
    } 
