    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(DeviceEditViewModel devm)
    {
        if (ModelState.IsValid)
        {
            devm.device.CategoryId = devm.SelectedCategory; // <- Main thing to do
            db.Entry(devm.device).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(devm);
    }
