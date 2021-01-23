    [HttpPost]
    public ActionResult Create(Doctor doc)
    {
      your_dbcontext db = new your_dbcontext();
      db.Add<Doctor>(doc);
      db.SaveChanges();
      return RedirectToAction("Index");
    }
