    [HttpPost]
    public ActionResult Create(CreateLogViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        // Redisplay the form with errors
        return View(model);
    }
