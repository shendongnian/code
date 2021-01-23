        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditSoftwareTrackingViewModel softwaretracking)
        {
            if (ModelState.IsValid)
            {
                db.SoftwareTrackings.Attach(softwaretracking);
    
                db.Entry(softwaretracking).Property(a => a.Computer).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.ComputerId).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.LastModified).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.Computer).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.Software).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.SoftwareAction).IsModified = true;
        
                db.Entry(softwaretracking).Property(a => a.SoftwareActionId).IsModified = true;
                db.Entry(softwaretracking).Property(a => a.SoftwareId).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            GeneratePageData(softwaretracking.Software.Id);
            return View(softwaretracking);
        }
