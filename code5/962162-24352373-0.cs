    YourDbContext _db= new YourDbContext();
    Area oldArea = _db.Areas.Where(x => x.ID == area.ID).FirstOrDefault();
      // Bind others properties marked with required from database 
       area.x = oldArea.x;
       area.y = oldArea.y;
    if (ModelState.IsValid)
    {
        db.Entry(area).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    ViewBag.Detector = new SelectList(db.Detectors, "DetectorCode", "detectorName", area.Detector);
    ViewBag.Grade = new SelectList(db.Grades, "Gradeid", "GradeName", area.Grade);
    return View(area);
}
