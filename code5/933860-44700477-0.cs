            Product thisProduct = db.Products.Where(p => p.Id == product.Id).FirstOrDefault();
            product.Url = thisProduct.Url;
        }
        if (ModelState.IsValid)
        {
            db.Set<Product>().AddOrUpdate(product);
            //db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
