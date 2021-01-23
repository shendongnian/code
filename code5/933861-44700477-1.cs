    // Add this to your controller to check if the file is coming empty, If yes then I copy my previous Url to the new edited object
    else if (file== null)
            {
                Product thisProduct = db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
                product.Url = thisProduct.Url;
            }
        if (ModelState.IsValid)
        {
    // had to use AddOrUpdate instead of Modified
            db.Set<Product>().AddOrUpdate(product);
            //db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
