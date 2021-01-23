    [HttpPost]
    public ActionResult CreateNewsItem(NewsItemViewModel model)
    {
        if (ModelState.IsValid)
        {
            // map view model to entity
            var newsItem = new NewsItem
            {
                Title = model.Title,
                Category = model.Category,
                // and so on
            }
            db.NewsItems.Add(newsItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        model.CategoryChoices = db.Categories.Select(m => new SelectListItem { Value = m.Name, Text = m.Name });
        return View(model);
    }
