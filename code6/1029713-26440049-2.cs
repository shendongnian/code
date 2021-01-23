    var finalResults = new Dictionary<List<fruit>, List<string>>();
    foreach (var subkey in GetAllSubsetsOf(searchList))
    {
        if (!subkey.Any())
        {
            continue; //I assume you don't want results for an empty key (hence "-1" above)
        }
        var conjunction = new HashSet<string>(partialResults[subkey.First()]);
        foreach (var e in subkey.Skip(1))
        {
            conjunction.IntersectWith(partialResults[e]);
        }
        
        finalResults.Add(subkey, conjunction.ToList());
    }
