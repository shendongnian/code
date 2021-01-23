    List<IntermediateResult> candidates = new List<IntermediateResult>();
    foreach (var item in search)
    {
        var lowerItem = item.ToLower();
        var matches = from a in query
                      where a.Company.Name.ToLower() == lowerItem
                         || a.FullDescription.ToLower() == lowerItem
                         || a.Title.ToLower == lowerItem
                      select new IntermediateResult { ID = a.ID, Search = lowerItem,
                          Title = a.Title.ToLower(),
                          Name = a.CompanyName.ToLower(), Desc = a.FullDescription.ToLower() };
        candidates.AddRange(matches);
    }
