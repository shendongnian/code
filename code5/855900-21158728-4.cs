    public static IEnumerable<List<T>> ToConsecutiveGroups<T>(
        this IEnumerable<T> source, Func<T,T, bool> isConsequtive)
    {
        using (var iterator = source.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            else
            {                    
                T current = iterator.Current;
                List<T> group = new List<T> { current };
                while (iterator.MoveNext())
                {
                    T next = iterator.Current;
                    if (!isConsequtive(current, next))
                    {
                        yield return group;
                        group = new List<T>();                            
                    }
                    current = next;
                    group.Add(current);
                }
                if (group.Any())
                    yield return group;
            }                
        }
    }
    
