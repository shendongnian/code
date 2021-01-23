    protected bool ContainsSubstring(string cityName, List<string> strings)
    {
     foreach(string subString in strings)
     {
      if (cityName.Contains(subString)) return true;
     }
     return false;
    }
...
    List<City> cities = db.Cities.Where(c => this.ContainsSubstring(c.name, strings));
    
