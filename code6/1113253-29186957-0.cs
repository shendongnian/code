    public class MyClass
    {
        public static MyClass Instance
        {
            get
            {
                return instanceLazy.Value;
            }
        }
        private static Lazy<MyClass> instanceLazy = 
            new Lazy<MyClass>(() => new MyClass());
        private MyClass()
        {
        }
    }
