    public static IEnumerable<T> ShuffleRemove<T>(this IEnumerable<T> enumerable, T item)
    {
        var count = enumerable.Count();
    
        var last = enumerable.ElementAt(count - 1);
    
        var found = false;
    
        for (int i = 0; i < count - 1; i++)
        {
            var current = enumerable.ElementAt(i);
    
            if (!found && item.Equals(current))
            {
                yield return last;
                found = true;
            }
            else
            {
                yield return current;
            }
        }
    
        yield break;
    }
