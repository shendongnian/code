    public ActionResult ListProductsbyId(int? id)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
    
            listOfProducts = db.getAll(id);
    
            return View(listOfProducts);
        }
        public ActionResult ListProductsByIdAndTull (int id, string tull)
        {
            var db = new DBProduct();
            List<Product> listOfProducts;
    
            listOfProducts = db.getAll(id,tull);
    
            return View(listOfProducts);
        }
