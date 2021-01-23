    var divisions = db.MarketingLookup.AsEnumerable()
                                      .Select(ml=>ml.Division)
                                      .OrderBy(division=>division) 
                                      .Distinct()
                                      .Select(division => new SelectListItem
                                      {
                                         Text = division,
                                         Value = division
                                      }).ToList();
