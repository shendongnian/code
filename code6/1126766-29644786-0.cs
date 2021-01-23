    public class ProductController : Controller
    {
        public ActionResult Index(long Id)
        {
            return View(GetProductList().FirstOrDefault(x => x.Id == Id));
        }
    
        public ActionResult Products()
        {
    
            return PartialView(GetProductList());
        }
    
        private IList<Product> GetProductList()
        {
            var productList = Session["ProductsList"];
    
            if (productList != null)
            {
                return productList;
            }
    
            productList = ProductManager.ReadProducts();
            Session["ProductsList"] = productList;
    
            return productList;
        }
    }
