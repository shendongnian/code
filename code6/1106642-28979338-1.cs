    public ActionResult ProjectReport(DateTime searchDate)
    {
      var projects = db.Projects
        .Where(c=>c.ActualSDate == searchDate)
        .ToList();
      return View(projects);
    }
