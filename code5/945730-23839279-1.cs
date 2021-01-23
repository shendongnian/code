    [HttpPost]
    public ActionResult Index(UserActivity activity)
    {
        if (ModelState.IsValid)
        {
            _db.UserActivities.Add(activity);
            _db.SaveChanges();
        }
        // Remove the ActivityId from your ModelState before returning the View.
        ModelState.Remove("ActivityId")
        return View(_db.Activities.ToList());
    }
