    public class ProductController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://yourapi.com/api/products");
            var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
            return View(products);
        }
    }
