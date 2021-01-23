    public class CustomerController : Controller
    {
        IGenericRepository<Customer> _customerRepo;
        IMapper<Customer, CustomerViewModel> _mapper;
    
        public CustomerController(
            IMapper<Customer, CustomerViewModel> customerRepository,
            IMapper<Customer, CustomerViewModel> customerMapper)
        {
            _customerRepo = customerRepository;
            _customerMapper = customerMapper;
        }
    
        public ActionResult Get(int id)
        {
            CustomerViewModel vm;
            using (_customerRepo)  // <- This looks fishy
            {
                Customer cust = _customerRepo.Get(id);
                vm = _customerMapper.MapToViewModel(cust);
            }
            return View(wm);
        }
    
        public ActionResult Update(CustomerViewModel vm)
        {
            Customer cust = _customerMapper.MapToModel(vm);
            CustomerViewModel updatedVm;
            using(_customerRepo)  // <- Smells like 3 week old flounder, actually
            {
                Customer updatedCustomer = _customerRepo.Store(cust);
                updatedVm = _customerMapper.MapToViewModel(updatedCustomer);
            }
            return View(updatedVm);
        }
    }
