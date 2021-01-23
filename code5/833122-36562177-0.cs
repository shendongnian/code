    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Attach(vendor);
                 db.Entry(vendor).State = EntityState.Modified;
                db.Entry(vendor).CurrentValues.SetValues(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }
