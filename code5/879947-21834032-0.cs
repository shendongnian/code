    List<string> matchedItems = new List<string>();
    List<string> listToWorkOn = new List<string>(list);
    while(listToWorkOn.Any())
    {
        var firstIndex = listToWorkOn.FindIndex(r => r.Contains('{'));
        var secondIndex = listToWorkOn.FindIndex(r => r.Contains('}'));
        matchedItems.AddRange(listToWorkOn.Skip(firstIndex + 1).Take(secondIndex - (firstIndex + 1)));
        listToWorkOn = listToWorkOn.Skip(secondIndex + 1).ToList();
    }
