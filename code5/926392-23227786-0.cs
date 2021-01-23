    var words = Regex.Split(input, @"\W+")
                     .GroupBy(w => w)
                     .Select(g => new { g.Key, Count = g.Count() })
                     .Where(g => g.Count > 10)
                     .ToDictionary(g => g.Key, g => g.Count);
