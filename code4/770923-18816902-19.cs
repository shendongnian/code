    public class CustomersController : Controller
    {
        private readonly JsonServiceClient _client;
        public CustomersController(JsonServiceClient client)
        {
            _client = client;
        }
        public ActionResult Search(SearchViewModel model)
        {
            var customers = _client.Get(new GetCustomers
            {
                LastName = model.LastName
            });
            return View(customers);
        }
    }
