    public class MyInterfaceImplementation : IMyInterface
    {
        private static MyInterfaceImplementation instance;
        private static readonly object lockObj = new object();
        private MyInterfaceImplementation() { }  //private .ctor
        public static MyInterfaceImplementation Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        instance = new MyInterfaceImplementation();
                    }
                }
                return instance;
            }
        }
        public void MyInterfaceMethod()
        {
            //Implement here
        }
    }
