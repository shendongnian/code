    private void PopulateCategoryChoices(AssetViewModel model)
    {
        model.CategoryChoices = db.Categories.Select(m => new SelectListItem
        {
            Value = m.Id,
            Text = m.Name
        };
    }
