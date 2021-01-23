    public abstract class BaseClass
    {
        //Concurrent Set does not exist.
        private static ConcurrentDictionary<Type, bool> _registeredTypes 
                = new ConcurrentDictionary<Type, bool>();
        protected BaseClass()
        {
            _registeredTypes.GetOrAdd(GetType(), RegisterType);
        }
        private static bool RegisterType(Type type)
        {
            //some code that will perform one time processing using reflections
            
            //dummy return value
            return true;
        }
    }
    public class ChildClass : BaseClass
    {
    }
