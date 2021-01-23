    List<City> cities = new List<City>();
    foreach(string subString in strings)
    {    
    cities.AddRange(db.Cities.Where(c => c.name.Contains(subString));
    }
