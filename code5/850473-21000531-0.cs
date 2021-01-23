    public class Class1
    {
        private Class1()
        {
            ...
        }
    
    
        private static readonly Class1 _instance = new Class1();
    
        public static Class1 Instance { get { return _instance; } }
    }
