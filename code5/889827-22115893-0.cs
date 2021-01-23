    public ActionResult Create(int? id)
    {
        var job = new Job();
        if (id.HasValue)
            job.IncidentID = id.Value;
        ViewBag.ActionCode = new SelectList(db.ActionTypes, "ActionCode", "ActionCode");
        return View(job);
    }
