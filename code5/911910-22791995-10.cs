    var lists = new SortedList<string, SortedList<string, string>>
    {
        {
            "foo",
            new SortedList<string, string>
            {
                { "0", "lol" },
                { "1", "skadoosh!" },
                { "2", "OMG!" }
            }
        }
    };
    
    foreach (var list in lists)
    {
        foreach (var kvp in list.Value)
        {
            Console.WriteLine("({0}, {1})", kvp.Key, kvp.Value);
        }
    }
