    bool firstIteration = true;
    foreach(var sample in selected)
    {
        int number = Int32.Parse(sample.proj.Last().ToString());
        if (number == 1 && !firstIteration)
        {
            // we just started a new cycle...
            int expectedNumberOfValues = values.Values.Max(list => list.Count);
            values = values.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.Concat(Enumerable.Repeat(0, expectedNumberOfValues - kvp.Value.Count)).ToList());
        }
        values[number].Add(sample.WDC);
        firstIteration = false;
    }
