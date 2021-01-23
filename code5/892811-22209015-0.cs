    public ActionResult Table()
        {
            ProductTable product = new ProductTable();
            product.Name = "AAA";
            dbproducts.Products.Add(product);
            dbproducts.SaveChanges();
            return View(product);
        }
