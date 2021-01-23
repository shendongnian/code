    public static IEnumerable<T> ShuffleRemove<T>(this IEnumerable<T> enumerable, T item)
    {
        var count = enumerable.Count();
    
        var last = enumerable.ElementAt(count - 1);
    
        for (int i = 0; i < count - 1; i++)
        {
            yield return item.Equals(enumerable.ElementAt(i)) ? last : enumerable.ElementAt(i);
        }
    
        yield break;
    }
