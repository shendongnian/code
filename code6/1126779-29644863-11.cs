	public class ProductController : Controller
    {
        public List<Product> ProductsList = ProductManager.ReadProducts();
	    [OutputCache(Duration=60, VaryByParam="*")] 
        public ActionResult Index(long Id)
        {
            return View(ProductsList.FirstOrDefault(x => x.Id == Id));
        }
		
		[OutputCache(Duration=60, VaryByParam="none")]
        public ActionResult Products()
        {
            return PartialView(ProductsList);
        }
    }
