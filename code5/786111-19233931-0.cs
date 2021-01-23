    public class MyLib 
    {
        public static void InitializeMyLib(...)
        {
            if (instance != null)
            {
                throw new InvalidOperationException("Already initialized");
            }
            instance = new MyLib(...);
        }
        public static MyLib GetInstance()
        {
            if (instance == null)
            {
                throw new InvalidOperationException("Not initialized");
            }
            return instance;
        }
        private MyLib(...)
        {
            ...
        }
        private static MyLib instance;
    }
    public class LibItem1
    {
        public LibItem1()
        {
            MyLib.GetInstance(); // will throw if doesn't exist
        }
    }
