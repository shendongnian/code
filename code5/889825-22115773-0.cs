    public ActionResult Create(int? id)
    {
        var model = new Job { IncidentID = id.GetValueOrDefault(0) };
        //or var model = new Job { IncidentID = (int.parse(id) };
        ViewBag.ActionCode = new SelectList(db.ActionTypes, "ActionCode", "ActionCode");
    
        return View(model);
    }
