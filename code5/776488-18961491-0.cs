    SelectListItem defaultItem = new SelectListItem 
    { 
        Selected = true, 
        Text = "Select", 
        Value = "NONE" 
    };
    List<SelectListItem> listOfDeliveryRuns = deliveries
        .Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Name,
            Selected = false
        })
        .Concat(defaultItem)
        .ToList();
