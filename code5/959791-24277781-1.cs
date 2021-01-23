    Dictionary<string, int> _teams = new Dictionary<string, int>();
    _teams.Add("Australia", 5);
    _teams.Add("England", 6);
    ...
    foreach( KeyValuePair<string, int> kvp in _teams )
    {
        Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
    }
