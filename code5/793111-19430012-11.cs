    public class HomeController : Controller
    {
    	private readonly IRepository<User> _userRepository;
    	
    	public HomeController()
    	{
    		_userRepository = new EfRepository<User>();
    	}
    	
    	public ActionResult Index()
    	{
    		var users = _userRepository.GetAll();
    		var inactiveUsers = _userRepository.Table.Where(u => !u.Active).ToList();
    	}
    }
