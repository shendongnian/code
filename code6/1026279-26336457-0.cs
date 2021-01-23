    public class test
    {
        private static test singleInstance = new test();
        public static test SingleInstance { get { return singleInstance; } }
        
        somedll g = new somedll();
        somedll h = new somedll();
    
        public void Stop(int module)
        {
            // ...
        }
    
        private void WriteCommand(int module, string command)
        {
            // ...
        }
    }
