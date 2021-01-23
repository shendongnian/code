    public ActionResult Edit(int? ID)
    {
      ....
      Product product = db.Products.Find(id);
      ProductVM model = new ProductVM();
      // map properties
      ....
      // populate select list (assumes Shop has properties ID and Name)
      model.ShopList = new SelectList(db.Shops, "ID", "Name");
      return View(product);
    }
