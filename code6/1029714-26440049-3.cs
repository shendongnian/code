    foreach (var kvp in WobblesFruitBaskets)
    {
        foreach (var f in kvp.Key)
        {
            List<string> value;
            if (!FruitBaskets.TryGetValue(f, out value))
            {
                value = new List<string>();
                FruitBaskets.Add(f, value);
            }
            
            value.Add(kvp.Value);
        }
    }
