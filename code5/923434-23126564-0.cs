    Dictionary<string, string> dict1 = new Dictionary<string, string>();
    Dictionary<string, string> dict2 = new Dictionary<string, string>();
    Dictionary<string, KeyValuePair<string, string>> complexdicts = new Dictionary<string, KeyValuePair<string, string>>();
    dict1.Add("A", "1");
    dict1.Add("B", "2");
    dict2.Add("A", "2");
    dict2.Add("C", "3");
    dict2.Add("D", "4");
    var allKeys = dict1.Keys.Union(dict2.Keys);
    foreach (var key in allKeys)
    {
        string val1;
        if (!dict1.TryGetValue(key, out val1))
        {
            val1 = "Not Available";
        } 
        string val2;
        if (!dict2.TryGetValue(key, out val2))
        {
            val2 = "Not Available";
        }
        complexdicts.Add(key, new KeyValuePair<string, string>(val1, val2));
    }
