    [HttpPost]
    public ActionResult Create(TipViewModel model)
    {
        if (ModelState.IsValid)
        {
            // map the data from model to your entity
            var tip = new Tip
            {
                Name = model.Name,
                Description = model.Description,
                Partner = db.Partners.Find(model.SelectedPartnerId),
                Book = db.Books.Find(model.SelectedBookId)
            }
            db.Tips.Add(tip);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Form has errors, repopulate choices and redisplay form
        PopulateChoices(model);
        return View(model);
    }
