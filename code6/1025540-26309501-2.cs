    Dictionary<string, List<string>> myCollection = new Dictionary<string, List<string>>();
    for (...)
    {
        if (!myCollection.ContainsKey("a"))
            myCollection.Add("a", new List<string>());
        myCollection["a"].Add("some_item");
    }
