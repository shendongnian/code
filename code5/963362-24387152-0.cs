    foreach (var line in input)
    {
        var elements = line.Split(' ');
        if (elements.Count > 1)
        {
            var t = elements
                .Select(i => Convert.ToInt32(i))
                .Distinct()
                .OrderBy(i => i)
                .Select(i => i.ToString())
                .ToArray();
            Console.WriteLine("\t" + string.Join(" ", t));
        }
    }
