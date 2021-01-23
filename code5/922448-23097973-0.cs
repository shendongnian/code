    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(LogViewModel logViewModel)
    {
        if (ModelState.IsValid)
        {
            // convert from ViewModel to Entity Model
            Log log = new Log(logViewModel);
            // parse the time
            log.Time = DateTime.ParseExact(logViewModel.Time, "dd/MM/yyyy HH:mm", null);
            db.Logs.Add(log);
            db.SaveChanges();
            TempData["Notification"] = AlertGenerator.GenerateAlert(AlertGenerator.Level.Success, "Success! Log Saved");
            return RedirectToAction("Index");
        }
        return View(log);
    }
