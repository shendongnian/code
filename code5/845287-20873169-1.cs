        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sample(Sample model)
        {
            if (ModelState.IsValid)
            {
                // Added Line
                db.Samples.Attach(model);
                db.Entry(model.Saloon).State = EntityState.Modified;
                db.Entry(model.Room).State = EntityState.Modified;
                db.Entry(model.Balcony).State = EntityState.Modified;
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
