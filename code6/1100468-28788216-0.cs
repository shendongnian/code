    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ProductSubArea> listProductSubAreas = new List<ProductSubArea>();
            int productID = 3;
            int productAreaID = 3;
            ProductSubArea psa1 = new ProductSubArea();
            psa1.ProductID = 1;
            psa1.ProductAreaID = 1;
            psa1.ProductAreaName = "Test1";
            psa1.SubProductArea = "SubTest1";
            listProductSubAreas.Add(psa1);
            ProductSubArea psa2 = new ProductSubArea();
            psa2.ProductID = 2;
            psa2.ProductAreaID = 2;
            psa2.ProductAreaName = "Test2";
            psa2.SubProductArea = "SubTest2";
            listProductSubAreas.Add(psa2);
            var returnList = listProductSubAreas
                .Where(o => o.ProductID == productID && o.ProductAreaID == productAreaID)
                .OrderBy(o => o.ProductAreaName)
                .Select(o => new SelectListItem { Text = o.SubProductArea, Value = o.SubProductArea })
                .DistinctBy(o => new { o.Text, o.Value })
                .ToList();
            int count = returnList.Count();
            return View();
        }
    }
    public class ProductSubArea
    {
        public int ProductID { get; set; }
        public int ProductAreaID { get; set; }
        public string ProductAreaName { get; set; }
        public string SubProductArea { get; set; }
    }
