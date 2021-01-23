    public ActionResult Edit(Branch branch)
    {
        if (ModelState.IsValid)
        {
            db.Entry(branch).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(branch);
    }
