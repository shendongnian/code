    public static class Program
    {
        public static void Main(string[] args) 
        {
            // Begin composition root
            var container = ConfigureContainer();
            var application = container.Resolve<ApplicationLogic>();
            // End composition root
            application.Run(args); // Pass runtime data to application here
        }
        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<ApplicationLogic>.AsSelf();
            builder.RegisterType<Log>().As<ILog>();
            // Register all dependencies (and dependencies of those dependencies, etc)
            return builder.Build();
        }
    }
    public class ApplicationLogic
    {
        private readonly ILog log;
    
        public ApplicationLogic(ILog log) {
            this.log = log;
        }
    
        public void Run(string[] args) {
            this.log.Write("Hello, world!");
        }
    }
