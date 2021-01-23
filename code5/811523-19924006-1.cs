    [HttpGet]
        public ActionResult AddProduct(int? id)
        {
            Models.ProductsModels.Products product = new Models.ProductsModels.Products();
    
            ViewBag.ListOfCategories = new SelectList(_cat.GetCategory(), "CategoryId", "CategoryName");
            ViewBag.ListOfBrands = new SelectList(_brad.GetAllBrands(), "BrandId", "BrandName");
    
            int productId = id ?? 0;
    
            if (id.HasValue)
            {
                ICS.Data.Product _prod = (new ProductController()).GetProductById(productId);
                product.ProductId = _prod.ProductId;
                product.ProductName = _prod.ProductName;
                product.CategoryId = _prod.Category_CategoryId;
                product.BrandId = _prod.Brand_BrandId;
                product.PriceSettings = _prod.IsFixed;
                product.PurchasePrice = (float)_prod.PurchasePrice;
                product.ItemPrice = (float)_prod.ItemPrice;
                product.Vat = (double)_prod.Vat;
                product.WholeSalePrice = (float)_prod.WholeSalePrice;
                product.RetailPrice = (float)_prod.RetailPrice;
                product.Comments = _prod.Comments;         
            }
    
            return View(product);
        }
