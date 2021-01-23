    // It would be better, if make the conversion only once and not each time you try to fetch an item
    // from your collection.
    int value = Convert.ToInt32(parts[0]);
    var list = results.AsEnumerable()
                      .OrderBy(z => Math.Abs(value - Convert.ToInt32(z.Zip)))
                      .Take(5)
                      .ToList();
