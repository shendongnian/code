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
