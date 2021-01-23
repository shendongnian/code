    var partialResults = new Dictionary<fruit, List<string>>();
    foreach (var key in searchList)
    {
        List<string> r;
        if (FruitBaskets.TryGetValue(key, out r))
        {
            partialResults.Add(key, r);
        }
    }
