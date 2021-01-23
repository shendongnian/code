    public class DalFactory
    {
        public static IDalFactory Factory { get set; }
    
        static DalFactory()
        {
            Factory = new DefaultDalFactory();
        }
    
    
        public static T Create<T>() where T : class
        {
            return Factory.Create<T>();
        }
    }
    
    public interface IDalFactory
    {
        T Create<T>() where T : class
    }
    
    public class DefaultDalFactory : IDalFactory
    {
        public T Create<T>() where T : class
        {
            return new T();
        }
    }
