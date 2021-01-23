    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
    
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    
        public ActionResult Index()
        {
            // Note: usually you should not use entities in view 
            // create appropriate view models and map entities to them
            var model = _userRepository.GetAll();
            return View(model);
        }
    }
