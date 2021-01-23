    Outcome[] outcomes = new[] { new Outcome { White = 0, Black = 0 },
                                 new Outcome { White = 1, Black = 0 },
                                 // ... all other possibilities
                                };
    // assume we have some list of combinations
    int max = 0;
    Combination maxCombination = null;
    foreach (var combination in combinations)
    {
        int min = int.MaxValue;
        foreach (var outcome in outcomes)
        {
            var count = combinations.Count(c => c != combination
                                             && Check(combination, c) == outcome);
            if (count < min)
                min = count;
        }
        if (min > max)
        {
            max = min;
            maxCombination = combination;
        }
    }
