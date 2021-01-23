    public ActionResult Edit(int id)
    {
        var tip = db.Tips.Find(id);
        if (tip == null)
        {
            return new HttpNotFoundResult();
        }
        var model = new TipViewModel
        {
            Name = tip.Name,
            Description = tip.Description,
            SelectedPartnerId = tip.Partner != null ? tip.Partner.Id : new int?(),
            SelectedBookId = tip.Book != null ? tip.Book.Id : new int?()
        }
        PopulateChoices(model);
        return View(model);
    }
