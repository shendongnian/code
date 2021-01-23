    [HttpPost]
    public ActionResult Create(CLASS Model)
    {
    		if (ModelState.IsValid)
    		{
    				db.Table.Add(Model);
    				db.SaveChanges();
    				return RedirectToAction("Index");
    		}
    		return View(Model);
    }
