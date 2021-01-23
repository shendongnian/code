    public class ProductViewModel
    {
        public IPagedList<Product> Products { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
    public ActionResult Index()
    {
        var model = new ProductViewModel();
        model.Products = // ... fetch from database
        model.Orders = // ... fetch from database
        return View(model);
    }
