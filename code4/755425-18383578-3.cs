    ...
    private SerializableDictionary<string, List<string>> dict;
    public Foo()
    {
        dict = new SerializableDictionary<string, List<string>>();
        dict.Add("list", new List<string>() { "test1", "test2" });
    }
