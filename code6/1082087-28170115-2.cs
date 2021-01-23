    var user = // get user
    var countryToAdd = db.Countries.FirstOrDefault(c => c.Name == countryName) ??
                           new Country() { Name = countryName };
    if (user.Countries == null)
        user.Countries = new List<Country>() { countryToAdd };
    else if (!user.Countries.Contains(countryToAdd))
        user.Countries.Add(countryToAdd);
    db.SaveChanges();
