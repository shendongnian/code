    var commonTitles = ac_CategoryList.Select(x=>x.Title)
                                      .Intersect(mw_CharityList.Select(x=>x.EntryTitle));
    var titleNotExitsCollection  = ac_CategoryList.Where(x=>!commonTitles.Contains(x.Title))
                                                  .ToList();
    var titleExitsCollection = mw_CharityList.Where(x=>commonTitles.Contains(x.EntryTitle))
                                             .ToList();
                                      
