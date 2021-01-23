    private static IEnumerable<SelectListItem> GetProductTypes()
    {
        //select prodtypes
        if (prodtypes != null && prodtypes.Count() > 0)
        {
            return prodtypes.Select(x => new SelectListItem
                   {
                        Value = x.Id.ToString(),
                        Text = x.Name
                   });
        }
        return new List<SelectListItem>();
    }
