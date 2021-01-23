    public class TestController : Controller
    {
        private readonly ICountryService _countryService;
        public TestController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET: /Test/
        public ActionResult Index()
        {
            var items = _countryService.GetAllCountries();
            return View(items.ToList());
        }
  }
