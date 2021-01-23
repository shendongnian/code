    var GeoLocations = rows.Select(r => new ElementSearchGeoLocation(r))
        .Where(t => (t.GeoLocationType == "State" && t.CanViewState(t.GeoLocationState, user)) ||
                    (t.GeoLocationType == "City" && t.CanViewCity(t.GeoLocationCity, user)));
    
    var predicate = PredicateBuilder.False();
    
    if(SystemList != 0)
    {
        predicate = predicate.Or(t => dto.SystemList.Contains(t.SystemID));
    }
    
    if (groupList != 0)
    {
        predicate = predicate.Or(t => dto.groupList.Contains(t.PoliticalID));
    }
    
    return Ok(GeoLocations.Where(predicate));
