    static class Program
    {
        public static MyService ServiceInstance;
        static Program()
        {
            ServiceInstance = new MyService ();
        }
        static void Main()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                ServiceInstance.StartInAttachedDebugger();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            }
            else
            {
                ServiceBase.Run(ServiceInstance);
            }
        }
    }
