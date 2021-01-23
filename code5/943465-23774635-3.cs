    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price,Rating")] MyModel obj)
    {
        if (ModelState.IsValid)
        {
            db.MyModel.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(obj);
    }
