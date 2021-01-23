    public static IEnumerable<int> FindSet(IEnumerable<int> amounts, int target)
    {
        var results = new Dictionary<int, List<int>>();
        results[0] = new List<int>();
        foreach(var amount in amounts)
        {
            for(int i = 0; i <= target; i++)
            {
                if(!results.ContainsKey(i) || results[i].Contains(amount))
                    continue;
                var combination = new List<int>(results[i]);
                combination.Add(amount);
                if (i + amount == target)
                    return combination;
                results[i + amount] = combination;
            }
        }
        return null;
    }
