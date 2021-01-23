    [HttpPost]
    public ActionResult Index(UserActivity activity)
    {
        if (ModelState.IsValid)
        {
            _db.UserActivities.Add(activity);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
