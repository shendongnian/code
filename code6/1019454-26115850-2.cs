    public class TestDalFactory : IDalFactory
    {
        [ThreadStatic]
        private static Dictionary<Type, object> _instances;
    
        public static Dictionary<Type, object> DalInstances
        {
            get
            {
                if (_instances == null)
                    _instances = new Dictionary<Type, Object>();
                return _instances;
            }
       }
    
        public static TestDalFactory Instance = new TestDalFactory();
        public T Create<T>() where T : class
        {
            return (T)_instances[typeof(T)];
        }
    }
