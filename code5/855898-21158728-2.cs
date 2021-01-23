    public static IEnumerable<List<int>> ToConsecutiveGroups(
        this IEnumerable<int> source)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            else
            {                    
                int current = iterator.Current;
                List<int> group = new List<int> { current };
                while (iterator.MoveNext())
                {
                    int next = iterator.Current;
                    if (next < current || current + 1 < next)
                    {
                        yield return group;
                        group = new List<int>();                            
                    }
                    current = next;
                    group.Add(current);
                }
                if (group.Any())
                    yield return group;
            }                
        }
    }
