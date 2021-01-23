    public static T[] ShuffleFromIndices<T>(this IList<T> items, IList<Int32> indices)
    {
        if (items == null)
            throw new ArgumentNullException("items");
        if (indices == null)
            throw new ArgumentNullException("indices");
        if (items.Count != indices.Count)
            throw new ArgumentException("items and indices have different lengths");
    
        T[] result = new T[items.Count];
    
        for (int i = 0; i < items.Count; i++)
        {
            var shuffleIndex = indices[i];
    
            result[i] = items[shuffleIndex];
        }
    
        return result;
    }
    
    public static Tuple<TKey[], TValue[]> SortNotInPlace<TKey, TValue>(IList<TKey> keys, IList<TValue> values)
    {
        if (keys == null)
            throw new ArgumentNullException("keys");
        if (values == null)
            throw new ArgumentNullException("values");
        if (keys.Count != values.Count)
            throw new ArgumentException("Keys and values have different lengths");
    
        var sortedKeysWithIndices = keys
            .Select((key, index) =>
                new { key, index })
            .OrderBy(keyIndex => keyIndex.key);
    
        var shuffleIndices = sortedKeysWithIndices
            .Select(keyIndex => keyIndex.index)
            .ToArray();
    
        var sortedValues = values.ShuffleFromIndices(shuffleIndices);
    
        var sortedKeys = sortedKeysWithIndices
                .Select(keyIndex => keyIndex.key)
                .ToArray();
    
        return new Tuple<TKey[], TValue[]>(sortedKeys,
            sortedValues);
    }
    
    static void Main(string[] args)
    {
        var keys = GetKeys();
        var values = GetValues();
    
        Console.WriteLine("Before");
        PrintKeyValues(keys, values);
    
    
        Console.WriteLine();
        Console.WriteLine("With LINQ");
    
        var sorted = SortNotInPlace(keys, values);
        var sortedKeys = sorted.Item1;
        var sortedValues = sorted.Item2;
        PrintKeyValues(sortedKeys, sortedValues);
    
        Console.ReadKey();            
    }
