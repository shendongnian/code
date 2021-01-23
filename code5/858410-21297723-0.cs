    public ActionResult Index(int? All = 2)
    {
        var propertyTypesSelectList = new SelectList(property_types.Select(x => new {v = x.Value, t = x.Key.ToLower()}), "v", "t", All).ToList();
        propertyTypesSelectList.Insert(0, new SelectListItem() { Value = "0", Text = "All items"});
            
        ViewData["All"] = propertyTypesSelectList;
        return View();
    }
