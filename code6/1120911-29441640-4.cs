    [HttpPost]
    public ActionResult Edit(Product product, string submitButton)
    {
          if(product.Expiration <= DateTime.Now && submitButton != "Save"){
             ModelState.AddModelError("Expiration", "Product is expired");
           }
    
           if (ModelState.IsValid)
           {
               db.Entry(product).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View(product);
    }
    
    
     
