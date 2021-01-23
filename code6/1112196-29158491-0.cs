    public ActionResult Index(int ID = 0)
    {
      DateTime firstOfWeek = DateTime.Today.AddDays(ID * 7).FirstOfWeek() // see notes below
      DateTime lastofWeek = firstOfWeek.AddDays(7).AddSeconds(-1);
      var consultantId = (int)Session["Id"];
      var timeReports = _db.TimeReports.Where(s => s.Date >= firstOfWeek && s.Date <= lastofWeek).Where(s => s.ConsultantID == consultantId); // don't need .ToList()
      ViewBag.PreviousWeek = ID - 1; // better to use a view model rather than ViewBag
      ViewBag.NextWeek = ID + 1; 
      return View("Index", timeReports);
    }
