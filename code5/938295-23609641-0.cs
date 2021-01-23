    var searchTypes = searchDetail.SearchType.Where(r => r.Value == true)
                                .ToDictionary(r => r.Key, r => r.Value);
    if (searchTypes.ContainsKey("CKBinstituteType"))
    {
    }
    if (searchTypes.ContainsKey("CKBstate"))
    {
    }
    if (searchTypes.ContainsKey("CKBlocation"))
    {
    }
    if (searchTypes.ContainsKey("CKBdistance"))
    {
    }
