    private static IEnumerable<SelectListItem> GetProductTypes()
    {
        //select prodtypes
        return prodtypes.Select(x => new SelectListItem
           {
                Value = x.Id.ToString(),
                Text = x.Name
           });
    }
