    Dictionary<string, int> matches = new Dictionary<string, int>();
    
    foreach(var item in document)
    {
        if(matches.ContainsKey(item.stringvalue))
        {
           matches[item.stringvalue] += 1;
        }
        else
        {
           matches.Add(item.stringvalue, 1);
        }
    }
