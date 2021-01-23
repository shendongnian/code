    public class ProduktiController : Controller
    {
        private ProduktiDBContext db = new ProduktiDBContext();
        public ActionResult Index()
        {
            ProductModel model = new ProductModel();
            model.Products = db.Products.ToList();
            foreach(var p in db.Products)
            {
                model.ProductsDropdownItems.Add(new SelectListItem() { Text = p.Title, Value = p.ID });
            }
           
            return View(model);
        }
    }
