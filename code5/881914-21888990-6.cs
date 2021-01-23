    [HttpPost]
    public ActionResult Edit(ProspectViewModel model)
    {
        if (ModelState.IsValid)
        {
            var prospect = new Prospect { /* populate with values from model */  };
            db.Prospects.Attach(prospect);
            db.Entry(prospect).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Need to repopulate drop down list
        //And we don't need to set SelectedProductId because it's already been posted back
        model.ProductList = db.Products.Select(x=> new SelectListItem { ... });
        
        return View(model);
    }
