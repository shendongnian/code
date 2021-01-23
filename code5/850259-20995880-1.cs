    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Product product)
    {
        ViewBag.NavProduct = "active";
        if (ModelState.IsValid)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        MultiSelectList taxes = new MultiSelectList(db.Taxes.ToList<Tax>(), "ID", "Name");
        ViewBag.AppliedTaxes = taxes;
        return View()
    }
