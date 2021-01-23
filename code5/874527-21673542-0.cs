    var numbers = File.ReadLines(path)
    .Where(line => !string.IsNullOrWhiteSpace(line) && line.Trim().All(Char.IsDigit))
    .Select(line => int.Parse(line))
    .OrderBy(i => i)
    .ToList();
    int min = numbers.Min();
    int max = numbers.Max();
    var gaps = Enumerable.Range(min, max - min + 1).Except(numbers);
    if(gaps.Any())
    {
        int firstGap = gaps.First();  // 4
        string allGaps = string.Join(",", gaps); 
    }
