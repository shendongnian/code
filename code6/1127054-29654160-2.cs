        ///
        /// ProductViewModel incoming model contains IList<> fields, and could be used as the view model for your page
        ///
        [HttpPost]
        public ActionResult Index(ProductViewModel requestModel)
        {
            // Create instance of the auto generated model (with ICollections)
            var product = new Product();
            // Map your incoming model to your auto generated model
            foreach (var productDetail in requestModel)
            {
                 product.ProductDetail.Add(new ProductDetail()
                 {
                     Product_ProductCategoryAttribute = productDetail.Product_ProductCategoryAttribute;
                     // Map other fields here
                 }
            }
            
            // Do something with your product
            this.MyService.SaveProducts(product);
            // Posted values will be retained and passed to view
            // Or map the values back to your valid view model with `List<>` fields
            // Or pass back the requestModel back to the view
            return View();
        }
