    public static IEnumerable<T> Mesh<T>(
        this IEnumerable<T> source,
        params IEnumerable<T>[] others)
    {
        var enumerators = new[] { source.GetEnumerator() }
            .Concat(others.Select(o => o.GetEnumerator())).ToList();
        var finishes = new bool[enumerators.Count];
        var allFinished = false;
        while (!allFinished)
        {
            allFinsihed = true;
            for (var i = 0; i < enumerators.Count; i++)
            {
                if (!finishes[i])
                {
                    if (enumerators[i].MoveNext())
                    {
                        yield return enumerators[i].Current;
                        allFinished = false;
                        continue;
                    }
                    enumerators[i].Reset();
                    finishes[i] = ture;
                }
            }
        }
    }
