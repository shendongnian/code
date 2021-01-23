    public class HomeController : Controller
    {
        private readonly IWebService _webServiceInfo;
        public HomeController(IWebService webServiceInfo) {
            _webServiceInfo = webServiceInfo;
        }
        public ActionResult Index() {
            var customers = _webServiceInfo.GetCustomers();
            var viewModel = customers.ConvertToMyViewModel();
            return View(viewModel);
        }
    }
