    List<Vector2> allKeysThatHaveAMatch = transportDictionary.Where(current =>
        transportDictionary.Count(other => current.Key.Y == other.Key.Y) > 1)
        .Select(item => item.Key)
        .ToList();
    while (allKeysThatHaveAMatch.Any())
    {
        // Get the first key
        var currentKey = allKeysThatHaveAMatch.First();
        // Get all matching keys
        var matchingKeys = allKeysThatHaveAMatch
            .Skip(1)
            .Where(candidateKey => candidateKey.Y == currentKey.Y)
            .Select(match => match)
            .ToList();
        // Do Something with each match
        foreach (var matchingKey in matchingKeys)
        {
            DoSomething(currentKey, matchingKey);
        }
        // Remove the key we just processed
        allKeysThatHaveAMatch.Remove(currentKey);
    }
