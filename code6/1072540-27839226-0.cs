    public class MyClass
    {
        private static MyClass _instance;
        public static MyClass Instance
        {
            get
            {
                if (_instance == null) { _instance = new MyClass(); }
                return _instance;
            }
        }
        private MyClass() { }
    }
