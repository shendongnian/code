	public class CustomerController : Controller
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly ICustomerRepository customerRepository;
		public CustomerController(
			IUnitOfWork unitOfWork, 
			ICustomerRepository customerRepository)
		{
			this.unitOfWork = unitOfWork;
			this.customerRepository = customerRepository;
		}
		public ActionResult List()
		{
			return View(customerRepository.Query());
		}
		[HttpPost]
		public ActionResult Create(Customer customer)
		{
			customerRepository.Add(customer);
			unitOfWork.SaveChanges();
			return RedirectToAction("List");
		}
	}
