    var itemsToIgnore = ModelState.Keys
        .Where(c => !Request.Form.AllKeys.Contains(c))
        .ToList();
    foreach (var item in itemsToIgnore)
    {
        ModelState.Remove(item);
    }
    if (ModelState.IsValid)
    {
        //all fields passed in were valid
    }
    
