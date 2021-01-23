    public class ProductController : Controller
    {
        public object Index(int? page)
        {
            var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?
    
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize
    
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
    }
