    public static class Program
    {
        public static void Main() {
            var container = ConfigureContainer();
            var application = container.Resolve<ApplicationLogic>();
            application.Run();
        }
    }
    public class ApplicationLogic
    {
        private readonly ILog log;
    
        public ApplicationLogic(ILog log) {
            this.log = log;
        }
    
        public void Run() {
            this.log.Write("Hello, world!");
        }
    }
