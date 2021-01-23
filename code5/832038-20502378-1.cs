    public class MySingletonClass {
        private static volatile MySingletonClass instance;
        private static object syncRoot = new object();
        private  MySingletonClass() { }
        public static MySingletonClass MySingletonClassInstance {
            get {
                    if (instance == null) {
                        lock (syncRoot) {
                            if (instance == null)
                                instance = new MySingletonClass();
                        }
                    }
                return instance;
            }
        }
        public void CallMySingleTonClassMethod() { }
    }
    public class program {
        static void Main() {
            //calling a 
            methodMySingletonClass.MySingletonClassInstance
                                  .CallMySingleTonClassMethod();      
            
        }
    }
