        [HttpPost]
        public ActionResult Index(MyModel requestModel)
        {
            var product = new Product();
            // Map your incoming model to your auto generated model
            foreach (var productDetail in requestModel)
            {
                 productList.ProductDetail.Add(new ProductDetail()
                 {
                     Product_ProductCategoryAttribute = productDetail.Product_ProductCategoryAttribute;
                     // Map other fields here
                 }
            }
            
            // Do something with your product list
            this.MyService.SaveProducts(productList);
            // Posted values will be retained and passed to view
            // Or map the values back to your valid view model with `List<>` fields
            return View();
        }
