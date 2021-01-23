    public ActionResult Create()
    {
        var model = new TipViewModel();
        PopulateChoices(model);
        return View(model);
    }
    ...
    protected void PopulateChoices(TipViewModel model)
    {
        model.PartnerChoices = db.Partners.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = m.Name
        });
        model.BookChoices = db.Books.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = string.Format("{0} by {1}", m.Name, m.Author)
        });
    }
