    public ActionResult Edit(int id)
    {
       var prospect = db.Prospects.Find(id);
       if (prospect == null)
       {
           return HttpNotFound();
       }
       var model = new ProspectViewModel
                       {
                          ProductList = db.Products.Select(x=> new SelectListItem { ... })
                       };
       
       return View(model);
    }
