    public ActionResult Index(string productname = "", string size = "0")
            {
                var oProdList = from ProdList in AddProducts() select oProdList;
    
    
          oProdList = oProdList.Where(oProd => oProd.SectionName.ToUpper().Contains(ProductName.ToUpper().Trim())|| oProd.Size == (double)size));
    
    
                ViewBag.ProductList = oProdList;
                return View();
    
            }
