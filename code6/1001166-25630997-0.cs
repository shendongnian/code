    [HttpGet]
    public ActionResult ProductEdit(Int32 ProductId)
    {
        var northwind = new NorthwindEntities();
    
        var q = from p in northwind.Products.AsEnumerable()  //to enumerate all records in memory and then use ToString
                where p.ProductID == ProductId
                select new ProductEditViewModel
                {
                    Product = p,
    
                    SupplierItems = from sup in northwind.Suppliers.AsEnumerable()  //to enumerate all records in memory and then use ToString
                                    select new SelectListItem
                                        {
                                            Text = sup.CompanyName,
                                            Value = sup.SupplierID.ToString(),  //to enumerate all records in memory and then use ToString
                                            Selected = sup.SupplierID == p.SupplierID
                                        },
    
                    CategorySelectedId = p.CategoryID,
                    CategorieItems = from cat in northwind.Categories.AsEnumerable() select cat,  //to enumerate all records in memory and then use ToString
                };
    
        return View(q.SingleOrDefault());
    }
    
    [HttpPost]
    public ActionResult ProductEdit(ProductEditViewModel vm)
    {
        return View();
    }
----------------
    public class ProductEditViewModel
    {
        public Product Product;
    
        // For DropDownListFor need IEnumerable<SelectListItem>
        public IEnumerable<SelectListItem> SupplierItems { get; set; }
    
        // For RadioButtonFor need below
        public Int32? CategorySelectedId { get; set; }
        public IEnumerable<Category> CategorieItems { get; set; }
    }
