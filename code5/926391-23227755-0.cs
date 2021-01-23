    var words = Regex.Split(input, @"\W+")
                        .AsEnumerable()
                        .GroupBy(w => w)
                        .Where(g => g.Count() > 10);
    foreach (var wordGrouping in words)
    {
        var word = wordGrouping.Key;
        var count = wordGrouping.Count();
    }
