    var personsWithDistance = results.ToList();
    foreach (Person p in personsWithDistance)
    {
        var pls = p.PersonLocations;
        foreach (PersonLocation pl in pls)
        {
            if (pl.Location.Geocode != null)
                pl.Location.Distance = Math.Round((double)(pl.Location.Geocode.Distance(_geo) / 1609.344), 1);
            else
                pl.Location.Distance = null;
        }
    }
    // order by distance
    personsWithDistance = personsWithDistance.OrderBy(r => r.PersonLocations.FirstOrDefault().Location.Distance).ToList();
    return personsWithDistance;
