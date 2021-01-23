    Dictionary<string, string> pNames = new Dictionary<string, string>(){
        {"a1", "asdf_a1"},
        {"a2", "asdf_a2"},
        {"a3", "asdf_a3"}
    };
    var bUsers = new List<string>() { "asdf_a2" };
    bUsers.ForEach(user => 
    {
        var Names = pNames.Where(name => name.Value == user).ToList();
        foreach (KeyValuePair<string, string> Name in Names)
            pNames.Remove(Name.Key);
    });
