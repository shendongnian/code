    public static IEnumerable<T[]> AllCobinations<T>(this IList<T> argsList)
    {
        for (int i = 1; i <= argsList.Count; i++)
        {
            foreach (var combo in argsList.Combinations(i))
            {
                yield return combo;
            }
        }
    }
