    private static ConcurrentDictionary<string, Lazy<StreamWriter>> _myDictionary =
        new ConcurrentDictionary<string, Lazy<StreamWriter>>();
    public static StreamWriter GetOrCreate(string fName)
    {
        return _myDictionary.GetOrAdd(fName,
            new Lazy<StreamWriter>(() => new StreamWriter(fName),
                LazyThreadSafetyMode.ExecutionAndPublication)).Value;
    }
