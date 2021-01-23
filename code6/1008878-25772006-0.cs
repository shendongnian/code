    public ActionResult Edit([Bind(Include = "Id,FirstName")] Person person, string FetchDate, string FetchTime) {
        if (ModelState.IsValid) {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(person);
    }
