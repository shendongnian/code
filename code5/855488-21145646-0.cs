    var max = data.Max(p => p.Value.Count);
    var result = 
    data.Select(p => new KeyValuePair<string, List<string>>(
                p.Key,
                p.Value.Count == max 
                   ? p.Value 
                   : p.Value.Concat(Enumerable.Repeat(p.Value.First(), 
                                                      max - p.Value.Count))
                            .ToList())
               );
