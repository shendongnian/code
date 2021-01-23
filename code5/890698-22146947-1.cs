    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var client = new HttpClient();
            var response = client.GetAsync("http://yourapi.com/api/products").Result;
            var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            return View(products);
        }
    }
