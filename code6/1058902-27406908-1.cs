    [HttpPost]
    public ActionResult Create(CompositeModel model)
    {
        if (ModelState.IsValid)
        {
            db.MediaPlans.Add(model.MediaPlanModel);
            db.ContactInfos.Add(model.ContactInfoModel);
            db.MediaPlanDates.Add(model.MediaPlanDateModel)
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);
    }
