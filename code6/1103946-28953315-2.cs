    public class HomeController : Controller
    {
        private readonly IOptions<ActiveDirectoryOptions> _activeDirectoryOptions;
    
        public HomeController(IOptions<ActiveDirectoryOptions> activeDirectoryOptions)
        {
            _activeDirectoryOptions = activeDirectoryOptions;
        }
    
        public IActionResult Index()
        {
            string domainName = _activeDirectoryOptions.Options.DomainName;
            ........
        }
    }
