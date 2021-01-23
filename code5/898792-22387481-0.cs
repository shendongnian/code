    var vTotals = list.GroupBy(i => i.fruit)
                    .ToDictionary(g => g.Key, g => g.Count());
    foreach (var fruit in Enum.GetValues(typeof(fruits)).Cast<fruits>()
                              .Where(x => !vTotals.ContainsKey(x)))
    {
        vTotals.Add(fruit, 0);
    }
