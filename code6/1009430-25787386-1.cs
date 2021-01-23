    public interface IClassA
    {
        void Method();
    }
    
    public class ClassA : IClassA
    {
        public void Method()
        {
            
        }
    }
    
    public static class ObjectInjector
    {
        public static T GetObject<T>()
        {
            object objReturn = null;
            if(typeof(T) == typeof(IClassA))
            {
                objReturn = new ClassA();
            }
            return (T)objReturn;
        }        
    }
    
    public class ClientClass
    {
       IClassA objA = ObjectInjector.GetObject<IClassA>();
       objA.Method();
    }
