    Dictionary<string, string> dict1 = new Dictionary<string, string>();
    Dictionary<string, string> dict2 = new Dictionary<string, string>();
    
    dict1.Add("A", "1");
    dict1.Add("B", "2");
    
    dict2.Add("A", "2");
    dict2.Add("C", "3");
    dict2.Add("D", "4");
    
    var allKeys = dict1.Keys.Union(dict2.Keys);
    
    // case 1
    List<Tuple<string, string, string>> unionValues = new List<Tuple<string, string, string>>();
    foreach (var key in allKeys)
    {
    	unionValues.Add(new Tuple<string, string, string>(key, dict1.ContainsKey(key) ? dict1[key] : "N/A" , dict2.ContainsKey(key) ? dict2[key] : "N/A"));
    }
    
    // case 2
    var result = (from key in allKeys
    			 select new Tuple<string, string, string>(key, dict1.ContainsKey(key) ? dict1[key] : "N/A", dict2.ContainsKey(key) ? dict2[key] : "N/A")).ToList();
