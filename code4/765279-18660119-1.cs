      //group things up as required
    var mainLookup = result
      .SelectMany(
        country => country.data,
        (country, data) => new {
          Name = country.Name,
          Year = data.Year,
          Val = data.Val
        }
      )
      .ToLookup(row => new {Name= row.Name, Year = row.Year}
    
    List<string> names = mainLookup
      .Select(g => g.Key.Name)
      .Distinct()
      .ToList();
    List<string> years = mainLookup
      .Select(g => g.Key.Year)
      .Distinct()
      .ToList();
    // generate all possible pairs of names and years
    var yearGroups = names
      .SelectMany(years, (name, year) => new {
        Name = name,
        Year = year
      })
      .GroupBy(x => x.Year)
      .OrderBy(g => g.Key);
    
    IEnumerable<string> results =
      (
      from yearGroup in yearGroups
      let year = yearGroup.Key
         //establish consistent order of processing
      let pairKeys = yearGroup.OrderBy(x => x.Name)
      let data = string.Join("\t",
        from pairKey in pairKeys
         //probe original groups with each possible pair
        let val = mainLookup[pairKey].FirstOrDefault()
        let valString = val == null ? "null" : val.ToString()
        select pairKey.Name + " " + valString
        )
      select year.ToString() + "\t" + data; //resultItem
