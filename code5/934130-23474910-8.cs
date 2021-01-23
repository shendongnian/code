    [HttpPost]
    public ActionResult Create(CreateDogModel model)
    {
        if (!ModelState.IsValid)
        {
            // fetch the humans again to populate the dropdown
            model.Humans =  db.Human.ToList();
            return View(model);
        }
        // create and persist a new dog
        return RedirectToAction("Index");
    }
