    public class CustomersController : Controller
    {
        private readonly CustomersService _customersService;
        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }
        public ActionResult Search(SearchViewModel model)
        {
            var customers = _customersService.Get(new GetCustomers
            {
                LastName = model.LastName
            });
            return View(customers);
        }
    }
