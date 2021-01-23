    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Head head)
    {
        if (ModelState.IsValid)
        {
            db.Entry(head).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	//Use automapper to map the objects or assign the data as below					
        HeadViewModel headViewModel = new HeadViewModel {
		// Assign the property value from the table object 
        };
        ViewBag.title_id = new SelectList(db.Titles, "title_id", "Titles", head.title_id);
        return View(headViewModel);
    }
    [HttpGet]
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Head head = db.Heads.Find(id);
        if (head == null)
        {
            return HttpNotFound();
        }
	//Use automapper to map the objects or assign the data as below					
	HeadViewModel headViewModel = new HeadViewModel {
		// Assign the property value from the table object
        };
        return View(headViewModel);
    }
