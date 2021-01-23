    public interface ISomeInterfaceInstances
    {
        ISomeInterface someInterface1 { get; }
        ISomeInterface someInterface2 { get; }
    }
    public class HomeController : Controller
    {
        public HomeController(IRepository repository, ISomeInterfaceInstances someInterfaces, IConfiguration configuration)
        {
            // Code
        } 
    }
