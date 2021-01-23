      public ActionResult ListProductsbyId(int id, string tull)
            {
                var db = new DBProduct();
                List<Product> listOfProducts;
                if(String.IsNullOrEmpty(tull)
                  {
                    listOfProducts = db.getAll(id);
                  }
                else
                 {
                 listOfProducts = db.getAll(id,tull);
                 }
        
                return View(listOfProducts);
            }
