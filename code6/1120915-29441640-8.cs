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
        
        // Here RETURN VIEW and MODEL
        
        
            return View(product);
        
        
                  }
                  else // Validate
                  {
                    if(product.Expiration <= DateTime.Now)
                    {
                      ViewBag.Message "Product is expired";
                      return View(product); // In the view the object property 'Category' is null. Why?
                    }
    
    // ALSO HERE YOU ARE NOT RETURNING A VIEW AND MODEL
    
    return View(product);
                  }
                }
