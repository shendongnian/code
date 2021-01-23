    private void PopulateItemChoices(FooViewModel model)
    {
        model.ItemChoices = db.Items.Select(m => new SelectListItem
        { 
            Value = m.Id.ToString(),
            Text = m.Name
        };
    }
