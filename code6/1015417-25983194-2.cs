    int url = lookup["url"]
        .Where(num => num.All(Char.IsDigit))
        .Select(int.Parse)
        .DefaultIfEmpty(int.MinValue)
        .First();    // int.MinValue if non-digits were detected
