    Dictionary<string, int> data = new Dictionary<string, int>();
    data.Add("Change1", 123);
    data.Add("Change2", 456);
    foreach (string key in data.Keys)
    {
        Console.WriteLine(key);
    }
