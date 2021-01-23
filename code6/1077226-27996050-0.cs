    public ActionResult Edit(int? id)
    {
        SoftwareTracking tracking = db.SoftwareTrackings.Find(id);
        EditSoftwareTrackingViewModel viewmodel = 
            Mapper.Map<SoftwareTracking, EditSoftwareTrackingViewModel>(tracking);
        return View(viewmodel);
    }
