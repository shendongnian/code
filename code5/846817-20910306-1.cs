    var city = context.Cities.Include(c => c.Districts.Select(d => d.Users))
        .SingleOrDefault(c => c.CityId == someCityId);
    if (city != null)
    {
        context.Cities.Remove(city);
        context.SaveChanges();
    }
