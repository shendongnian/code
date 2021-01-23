    public class AdminController : Controller
    {        
        private IUserRepository _repository;
        public AdminController(IUserRepository repository) 
        {
            _repository = repository; 
        }
    
        public ActionResult Index()
        {
            return View(_repository.Users);
        }
    }
