    public ActionResult CreateNewsItem()
    {
        var model = new NewsItemViewModel();
        model.CategoryChoices = db.Categories.Select(m => new SelectListItem { Value = m.Name, Text = m.Name });
        return View(model);
    }
