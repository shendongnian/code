    Dictionary<string, List<string>> myLists = new Dictionary<string, List<string>>();
    
    var s = "listname";
    myLists.Add(s, new List<string>());
    // To access
    var list = myLists[s];
