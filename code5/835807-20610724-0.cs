    public interface ISomeInterfaceEnumerator : IEnumerable<ISomeInterface>
    {        
    }
    public class HomeController : Controller
    {
        public HomeController(IRepository repository, ISomeInterfaceEnumerator someInterfaces, IConfiguration configuration)
        {
            // Code
        } 
    }
