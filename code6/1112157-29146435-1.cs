    var distinctCountries = CityObjectList
        .Select(c => c.Region.Country)
        .GroupBy(c => c.CountryCode)
        .Select(g => g.First())
        .ToList();
    
