    public static IList<T> DeepToList<T>(IEnumerable<T> source) where T : IClonable
    {
        IList<T> result = new List<T>();
        foreach (T t in source)
        {
            result.Add((T)t.Clone());
        }
        return result;
    }
    public static T[] DeepToArray<T>(IEnumerable<T> source) where T : IClonable
    {
        IList<T> clones =  DeepToList(source);
        T[] result = new T[clones.Count];
        clones.CopyTo(result, 0);
        return result;
    }
    public static T[] DeepToArray<T>(IList<T> source) where T : IClonable
    {
        T[] result = new T[source.Count];
        for (int i = 0; i < source.Count; i++)
        {
            result[i] = (T)source[i].Clone();
        }
        return result;
    }
