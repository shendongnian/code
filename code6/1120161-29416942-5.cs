    private Dictionary<int, Lazy<int>> values;
    private object sync = new object();
    public int GetData(int key)
    {
        Lazy<int> lazy;
        lock (sync)
        {
            if (!values.TryGetValue(key, out lazy))
            {
                lazy = new Lazy<int>(delegate
                {
                    return VeryExpensiveComputationMethod(key);
                });
                values.Add(key, lazy);
            }
        }
        return lazy.Value;
    }
