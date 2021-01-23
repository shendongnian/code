    public ActionResult Edit(EditSoftwareTrackingViewModel vm)
    {
        if (ModelState.IsValid)
        {
            vm.LastModified = DateTime.Now;
            var softwareTrack = db.SoftwareTrackings.Find(softwaretracking.Id);
            softwareTrack = 
               Mapper.Map<EditSoftwareTrackingViewModel, SoftwareTracking>(vm, softwareTrack);
            
            db.Entry(softwareTrack).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
