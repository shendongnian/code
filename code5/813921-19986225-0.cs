    public class HomeController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        public HomeController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }
    
        public ActionResult Index(int id)
        {
            var customer = _customerRepository.GetById(id)
            return View(customer);
        }
    }
