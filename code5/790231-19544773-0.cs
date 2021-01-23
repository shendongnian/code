    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Prefix = "Products")] IEnumerable<MedicalProductViewModelLineItem> productList, FormCollection values)
    {
        if (ModelState.IsValid)
        {
            foreach (var product in productList)
                _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        var productViewModelList = GetMedicalProductViewModel(productList);
        return View(productViewModelList);
    }
