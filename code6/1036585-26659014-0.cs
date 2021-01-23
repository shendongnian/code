    [HttpPost]
    // [ValidateAntiForgeryToken]
    [ValidateInput(false)]
    public ActionResult Index([Bind(Include = "appName")] RegTeg.Models.ApplicationName newAppName)
    {
        if (ModelState.IsValid)
        {
            db.ApplicationNames.Add(newAppName);
            db.SaveChanges();   //fails here due to a null column
            return RedirectToAction("Index");
        }
        //continue to return a list as your view is expecting
        //if you REALLY want only the item that you just created, then construct a list, 
        //add that to it, and return that instead of the full list
        return View(db.ApplicationNames.ToList());
    }
