    var divisions = db.MarketingLookup.AsEnumerable()
                                      .Select(x=>x.Division)
                                      .OrderBy(x=>x) 
                                      .Distinct()
                                      .Select(x => new SelectListItem
                                      {
                                         Text = x.Division,
                                         Value = x.Division
                                      }).ToList();
