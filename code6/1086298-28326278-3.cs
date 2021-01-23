    [HttpPost]
    public ActionResult Create(AssetViewModel model)
    {
        if (ModelState.IsValid)
        {
            var asset = new Asset
            {
                Title = model.Title,
                Description = model.Description,
                // etc.
                Categories = db.Categories.Where(m => model.SelectedCategoryIds.Contains(m.Id))
            }
            db.Assets.Add(asset);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        PopulateCategoryChoices(model);
        return View(model);
    }
