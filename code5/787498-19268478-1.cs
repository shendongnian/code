    var commonTitles = categoryList.Select(x=>x.Title.Trim())
                                   .Intersect(charityList.Select(x=>x.EntryTitle.Trim()));
    var titleNotExitsCollection  = categoryList.Where(x=>!commonTitles.Contains(x.Title))
                                               .ToList();
    var titleExitsCollection = charityList.Where(x=>commonTitles.Contains(x.EntryTitle))
                                          .ToList();
                                      
