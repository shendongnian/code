    var groupedByContinent = locations.GroupBy(x => x.Continent);
    var groupedByCountry = groupedByContinent.Select(group =>
        new
        {
            Key = group.Key,
            NestedGroup = group.ToLookup
                            (result => result.Country, result => result.Name)
        });
    var dictionary = groupedByCountry.ToDictionary
        (result => result.Key, result => result.NestedGroup);
    groupedLocations = dictionary;
