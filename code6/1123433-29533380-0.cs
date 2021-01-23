    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit (ProductDetailViewModel productDetailAll)
    {
        if (ModelState.IsValid)
        {
            ProductDetail productDetail = productDetailAll.ProductDetail;
            db.Entry(productDetail).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(productDetailAll);
    }
