    public class HomeController : Controller
    {
        public HomeController(IRepository repository, 
                   [Dependency("Impl1")] ISomeInterface someInterface1, 
                   [Dependency("Impl2")] ISomeInterface someInterface2, 
                   IConfiguration configuration)
        {
            // Code
        }
    }
