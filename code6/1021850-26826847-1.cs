    IQueryable<SelectListItem> query = db.Products;
    if(!allModels)
    {
      if(modelsEndingWithE) query = query.Where(model => model.Name.EndsWith("E"));
      if(modelsEndingWithoutE) uery = query.Where(model => !model.Name.EndsWith("E"));
    }
    
    query = query.Select(m => new SelectListItem() { Text = m.Name, Value = m.Id.ToString() })
    IList<SelectListItem> results= query.ToList();
