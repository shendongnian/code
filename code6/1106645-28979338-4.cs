    public ActionResult ProjectReport(DateTime? fromDate, DateTime? toDate)
    {
      if (!fromDate.HasValue) fromDate = DateTime.Now.Date;
      if (!toDate.HasValue) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
      if (toDate < fromDate) toDate = fromDate.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
      ViewBag.fromDate = fromDate;
      ViewBag.toDate = toDate;
    
      var projects = db.Projects
        .Where(c=>c.ActualSDate >= fromDate && c.ActualSDate < toDate)
        .ToList();
    
      return View(projects);
    }
