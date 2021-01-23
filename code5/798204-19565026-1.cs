    using System.ServiceProcess;
    using System.Threading;
     
    namespace myService
    {
        class Service : ServiceBase
        {
            static void Main()
            {
                ServiceBase.Run(new Service());
            }
     
            public Service()
            {
                Thread thread = new Thread(Actions);
                thread.Start();
            }
     
            public void Actions()
            {
                // Do Work
            }
        }
    }
