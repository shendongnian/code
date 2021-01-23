    // Randomly executes one of the given actions (KVP values). The probability
    // of a given action being chosen is proportional to its weight (KVP key).
    public static void RandomlyExecute(
        Random random,
        IEnumerable<KeyValuePair<double, Action>> choices)
    {
        double totalWeight = Enumerable.Sum(choices, choice => choice.Key);
        double x = random.NextDouble() * totalWeight;
        double y = 0;
        foreach (var choice in choices)
        {
            y += choice.Key;
            if (x <= y)
            {
                choice.Value();
                break;
            }
        }
    }
