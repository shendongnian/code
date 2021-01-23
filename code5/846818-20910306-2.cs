    var city = context.Cities.Include(c => c.Districts.Select(d => d.Users))
        .SingleOrDefault(c => c.CityId == someCityId);
    if (city != null)
    {
        foreach (var district in city.Districts)
            foreach (var user in district.Users.ToList())
                user.DistrictId = null;
        context.Cities.Remove(city);
        context.SaveChanges();
    }
