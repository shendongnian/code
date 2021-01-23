    public static Dictionary<T, U> DictionaryFromArrays<T,U>(T[] keys, U[] values)
    {
        return keys
          .Select((k, idx) => new {key = k, value = values[idx]})
          .ToDictionary(x => key, y => value);
    }
