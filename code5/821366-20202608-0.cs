    var city = context.Cities
        .Where(u => u.StateId == StateID)
        .GroupBy(u => u.CityName)
        .Select(g => new {
            cityId = g.First().CityId,
            cityName = g.Key
        });
