    public ActionResult Create()
    {
        var model = new Album();
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(Album model)
    {
        if (ModelState.IsValid)
        {
            db.Albums.Add(model);
            db.SaveChanges()
            return RedirectToAction("Index");
        }
        return View(model);
    }
