        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSoftwareTrackingViewModel softwaretracking)
        {
            if (ModelState.IsValid)
            {
                var softwareTrack = new SoftwareTracking
                {
                     Computer = softwaretracking.Computer,
                     ComputerId = softwaretracking.ComputerId,
                     LastModified = softwaretracking.LastModified,
                     Software = softwaretracking.Software,
                     SoftwareAction = softwaretracking.SoftwareAction,
                     SoftwareActionId = softwaretracking.SoftwareActionId,
                     SoftwareId = softwaretracking.SoftwareId,
                     EnteredDate = softwareTrack.EnteredDate
                };
                db.SoftwareTrackings.Attach(softwareTrack);
    
                db.Entry(softwareTrack).Property(a => a.Computer).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.ComputerId).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.LastModified).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.Computer).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.Software).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.SoftwareAction).IsModified = true;
        
                db.Entry(softwareTrack).Property(a => a.SoftwareActionId).IsModified = true;
                db.Entry(softwareTrack).Property(a => a.SoftwareId).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            GeneratePageData(softwaretracking.Software.Id);
            return View(softwaretracking);
        }
