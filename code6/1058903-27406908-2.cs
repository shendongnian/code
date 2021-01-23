    [HttpPost]
    public ActionResult Edit(CompositeModel model)
    {
        if (ModelState.IsValid)
        {
            db.Entry(model.MediaPlanModel).State = EntityState.Modified;
            db.Entry(model.ContactInfoModel).State = EntityState.Modified;
            db.Entry(model.MediaPlanDateModel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }
