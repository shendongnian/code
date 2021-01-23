        public class ServiceClass
        {
            public ServiceClass()
            {
            }
            public void Start() {  }
            public void Stop() {  }
        }
    
    public class Program
    {
         public static void Main(string[] args)
         {
            //we can simply install our service by setting specific commands for same or install it directly from command line or from another process
            if (args.Length == 0)
            {
                var processName = Process.GetCurrentProcess().ProcessName + ".exe";
                var install = Process.Start(processName, "install start");
                install.WaitForExit();
                return;
            }
    
            HostFactory.Run(x =>          
            {
                x.Service<ServiceClass>(s =>            
                {
                    s.ConstructUsing(name => new ServiceClass()); 
                    s.WhenStarted(tc => tc.Start());        
                    s.WhenStopped(tc => tc.Stop());         
                });
                x.RunAsLocalSystem();                     
    
                x.SetDescription("Topshelf Host");       
                x.SetDisplayName("TopShelf");               
                x.SetServiceName("TopShelf");                 
            });                                       
        }
    }
