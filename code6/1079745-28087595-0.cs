    var dictionaries = new Dictionary<string, Dictionary<int, int>>();
    foreach (Identity x in List.Identities)
    {
        dictionaries.add("shop" + x.Id, new Dictionary<int, int>());
        dictionaries.add("de" + x.Id, new Dictionary<int, int>());
        dictionaries.add("sell" + x.Id, new Dictionary<int, int>());
    }
