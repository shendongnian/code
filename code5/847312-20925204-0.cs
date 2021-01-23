    private static IEnumerable<IEnumerable<string>> FindAllCombinations(string[][] groups)
    {
        if (groups.Length == 0)
            yield break;
        var group = groups.First();
        var remainingGroups = groups.Skip(1).ToArray();
        var remainingCombinations = FindAllCombinations(remainingGroups).ToList();
        foreach (var element in group)
        {
            var elementList = new List<string>() { element };
            if (remainingGroups.Length > 0)
            {
                foreach (var c in remainingCombinations)
                {
                    yield return elementList.Concat(c).ToList();
                }
            }
            else
                yield return elementList;
        }
    }
