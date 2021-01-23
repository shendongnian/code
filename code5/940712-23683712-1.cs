    if (ModelState.IsValid)
    {
    IEnumerable<SelectListItem> countries = _DB.Countries.Where(x => x.Status == Status.Visible)
    					.Select(x => new SelectListItem()
    					{
    						Value = x.ID + "",
    						Text = "(+" +x.PhoneCountryCode + ") - " + x.Name
    					}).ToList();
    countries.First().Selected = true;
    }
    else
    {
      //We need to rebuild the dropdown or we're in trouble
       IEnumerable<SelectListItem> countries = _DB.Countries.Where(x => x.Status == Status.Visible)
                            .Select(x => new SelectListItem()
                            {
                                Value = x.ID + "",
                                Text = "(+" +x.PhoneCountryCode + ") - " + x.Name
                            }).ToList();
        countries.First().Selected = true;
    }
