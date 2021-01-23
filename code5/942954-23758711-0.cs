        public class SingletonIntializer<T>
    {
        public T GetInstance(params object[] @params)
        {
            if (!SingletonContainer.ContainsType(typeof(T)))
            {
                SingletonContainer.CreateInstance(typeof(T), @params);
            }
    
            return (T)SingletonContainer.GetInstance(typeof(T));
        }
    }
    
    internal static class SingletonContainer
    {
        private static Dictionary<Type, object> internalContainer = new Dictionary<Type, object>();
    
        public static bool ContainsType(Type type)
        {
            return internalContainer.ContainsKey(type);
        }
    
        public static bool CreateInstance(Type type, object[] @params)
        {   
            if (ContainsType(type))
            {
                return false;
            }
    
            internalContainer[type] = Activator.CreateInstance(type, @params);
            return true;
        }
    
        public static object GetInstance(Type type)
        {
            if (!ContainsType(type))
            {
                return null;
            }
    
            return internalContainer[type];
        }
    }
