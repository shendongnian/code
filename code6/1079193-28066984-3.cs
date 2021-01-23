    private static ConcurrentDictionary<string, Task<string[]>> data =
        new ConcurrentDictionary<string, Task<string[]>>();
    public static Task<string[]> GetStuffAsync(string key)
    {
        return data.GetOrAdd(key, LoadAsync);
    }
