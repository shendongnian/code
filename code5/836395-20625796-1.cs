    //the 1st option
    var orFilter = obj.Where(o => subs.Any(s => o.city.ToLower().Contains(s)))
                      .ToList();
    //the 2nd option
    var andFilter = obj.Where(o => subs.TrueForAll(s => o.city.ToLower().Contains(s)))
                       .ToList();
