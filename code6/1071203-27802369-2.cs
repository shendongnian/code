    public interface IEngine
    {
        bool TryGetCapability<T>(out T capability);
    }
    
    public interface ICapability1
    {
        void Foo();
    }
    
    public class Engine1 : IEngine, ICapability1
    {
        public bool TryGetCapability<T>(out T capability)
        {
            if (this is T)
            {
                capability = this as T;
                return true;
            }
            capability = default(T);
            return false;
        }
        
        public void Foo()
        {
            //...
        }    
    }    
    
    public class App1
    {
        public void Do()
        {
            IEngine e = new Engine1();
            ICapability1 cap1;
            if (e.TryGetCapability(out cap1))
            {
                cap1.Foo();
            }
        }
    }
