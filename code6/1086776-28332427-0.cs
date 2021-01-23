    IEnumerable<GeoLocation> subQuery;
    if (SystemList != 0)
       subQuery = AllLocations.Where(...);
    else
       subQuery = AllLocations.Where(...);
    
    var GeoLocations = mainQuery.Concat(subQuery);
