    // It would be better, if make the conversion only once instead of 
    // doing this each time we fetch an item from our collection.
    int value = Convert.ToInt32(parts[0]);
    var list = results.AsEnumerable()
                      .OrderBy(z => Math.Abs(value - Convert.ToInt32(z.Zip)))
                      .Take(5)
                      .ToList();
