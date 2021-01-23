    string num = db.SelectNums(id);
    string[] split = num.Split('-');
    
    long start = long.Parse(split[0]);
    long end = long.Parse(split[1]);
    bool includeLeadingZero = split[0].StartsWith("0");
    
    List<string> results = new List<string>();
    
    for(int i = start; i <= end; i++)
    {
        string result = includeLeadingZero ? "0" : "";
        result += i.ToString();
        results.Add(result);
    }
    
    string[] arrayResults = results.ToArray();
