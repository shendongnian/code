    ValidateModel(model);
    try
    {
        if (ModelState.IsValid)
        {
            db.INV_Models.Add(model);
            db.SaveChangesAsync();
        }
    }
    ...
