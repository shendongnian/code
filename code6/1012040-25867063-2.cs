    public class ClientHomeController : Controller
    {        
        public ActionResult Index()
        {            
            ProductList objPrdList = new ProductList();
            List<List<ProductMaster>> lstPrdList = new List<List<ProductMaster>>();
            List<ProductMaster> inner = new List<ProductMaster>();
            inner = db.ProductMasters.Where(x => x.isActive == true).OrderByDescending(x => x.CreatedOn).Take(10).ToList();
            int skip = 0;
            int take = 4;
            List<ProductMaster> pm;
            for (int i = 0; i < inner.Count / take; i++)
            {
                pm = new List<ProductMaster>();
                pm = inner.Skip(skip).Take(take).ToList();
                lstPrdList.Add(pm);
                skip += take;
            }
            pm = new List<ProductMaster>();
            pm = inner.Skip(skip).Take(inner.Count-skip).ToList();
            lstPrdList.Add(pm);
            objPrdList.lstPrdList = lstPrdList;
            return View(objPrdList);
        }
    }
