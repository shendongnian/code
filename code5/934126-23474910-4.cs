    [HttpPost]
    public ActionResult Create(CreateDogModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Humans =  db.Human.ToList();
            return View(model);
        }
        // create and persist a new dog
        return RedirectToAction("Index");
    }
