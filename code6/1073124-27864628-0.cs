    public class MyClass
    {
        static MyClass _instance = new MyClass();
        public static MyClass Instance
        {
            get
            {
                return _instance;
            }
            set { _instance = value; }
        }
        
        public void DoStuff()
        {
             //etc...
        }
        private MyClass()
        {
            
        }
    }
