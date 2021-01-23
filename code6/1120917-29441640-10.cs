       [HttpPost]
       public ActionResult Edit(Product product, string submitButton)
       {
        if(submitButton == "Save")
        {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
        }
           if(product.Expiration <= DateTime.Now)
           {
               ViewBag.Message "Product is expired";
           }
           return View(product);
       }
