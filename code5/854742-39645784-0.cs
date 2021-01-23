    **Your code must be like this**
    
    
    if (ModelState.IsValid)
                {
                    db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(movie);
