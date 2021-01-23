    public static T[] DeepToArray<T>(IEnumerable<T> source) where T : IClonable
    {
        T[] result = source.ToArray();
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = result[i].Clone();
        }
    }
