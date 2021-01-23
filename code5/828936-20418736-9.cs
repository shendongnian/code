    Outcome[] outcomes = new[] { new Outcome { White = 0, Black = 0 },
                                 new Outcome { White = 1, Black = 0 },
                                 // ... all other possibilities
                                };
    // assume we have some list of combinations
    int min = Integer.MaxValue;
    Combination minCombination = null;
    foreach (var guess in combinations)
    {
        int max = 0;
        foreach (var outcome in outcomes)
        {
            var count = 0;
            foreach (var solution in combinations)
            {
                if (Check(guess, solution) == outcome)
                    count++;
            }
            if (count > max)
                max = count;
        }
        if (max < min)
        {
            min = max;
            minCombination = guess;
        }
    }
